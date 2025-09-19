using ApiCognosV1.Data;
using ApiCognosV1.Migrations;
using ApiCognosV1.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiCognosV1.Controllers
{
    //[Route("api/")]
    //[ApiController]
    [Route("api/")]
    [ApiController]


    public class ArchivosterapeutasController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public ArchivosterapeutasController(IMapper mapper, ApplicationDBContext context, IWebHostEnvironment env)
        {
            
            _context = context;
            _mapper = mapper;
            _env = env;
        }
  
        // 🔹 Listar archivos (no eliminados)
        [HttpGet]
        [Route("Listaarchivos/{categoriaID}")]
        public IActionResult GetArchivos(int categoriaID)
        {
            var archivos = _context.Archivos
                .Where(a => !a.Eliminado && a.CategoriaId== categoriaID)
                .OrderByDescending(a => a.FechaSubida)
                .ToList();

            return Ok(archivos);
        }

        // 🔹 Descargar archivo por ID (devuelve la URL pública)
        [HttpGet("download/{id}")]
        public IActionResult Download(int id)
        {
            var archivo = _context.Archivos.FirstOrDefault(a => a.ArchivoId == id && !a.Eliminado);
            if (archivo == null)
                return NotFound("Archivo no encontrado o eliminado");

            // Construir la URL pública
            string baseUrl = "https://www.iescognos.com/";
            string fileUrl = baseUrl + archivo.Ruta; // archivo.Ruta ya tiene el nombre.pdf

            return Ok(new { url = fileUrl });
        }

        // 🔹 Subir archivo
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] string descripcion, [FromForm] int categoriaId)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("Archivo vacío o no seleccionado");

                // Nombre único
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

                // FTP config
                string ftpUrl = "ftp://ftp.iescognos.com/httpdocs/archivos/" + fileName;
                string ftpUser = "iescogno";
                string ftpPass = "Weyman#1586";

                // Subir archivo a FTP
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(ftpUser, ftpPass);

                using (var stream = request.GetRequestStream())
                {
                    await file.CopyToAsync(stream);
                }

                // Guardar en BD
                var archivo = new Archivo
                {
                    Nombre = file.FileName,
                    Descripcion = descripcion,
                    CategoriaId = categoriaId, // 🔹 Guardamos el valor del catálogo
                    Ruta = Path.Combine("archivos", fileName), // ruta relativa
                    ContentType = file.ContentType ?? "application/octet-stream",
                    FechaSubida = DateTime.Now,
                    Eliminado = false
                };

                _context.Archivos.Add(archivo);
                await _context.SaveChangesAsync();

                return Ok(archivo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Error al subir archivo por FTP",
                    error = ex.Message
                });
            }
        }


        // 🔹 Eliminado lógico
        [HttpDelete("deletearch/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var archivo = await _context.Archivos.FindAsync(id);
            if (archivo == null)
                return NotFound();

            archivo.Eliminado = true;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
