using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XAct;
using XAct.Library.Settings;

namespace ApiCognosV1.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ArchivoanexoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ArchivoanexoController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;

        }
        //Ruta para insertar maestro de pruebas històrico
        [HttpPost]
        [Route("MaestroAnexo")]
        public IActionResult InsertMaestroAnexoL(int maestro_id_paciente, string fecha, string observ)
        {
            DateTime enteredDate = DateTime.Parse(fecha);
            int idx = 0;
            //var respuesta = new Respuesta();
            if (maestro_id_paciente > 0)
            {
                Console.WriteLine(maestro_id_paciente);
                var objfiles = new Maestro_pruebas_hist()
                {
                    maestro_id = 0,
                    //Name = newFileName,
                    maestro_fecha = enteredDate,
                    maestro_tipo_prueba = 7,
                    maestro_id_paciente = maestro_id_paciente,
                    maestro_id_imagen = 0,
                    maestro_observacion = observ

                };
                _context.Maestro_pruebas_hist.Add(objfiles);
                _context.SaveChanges();
                idx = objfiles.maestro_id;

            }

            return Ok(new { id = idx });
        }


        //Obtiene los archivos de la tabla maestra
        [HttpGet]
        [Route("MaestroAnexoList/{Id}")]
        public IEnumerable<Maestro_pruebas_hist> MaestroAnexoList(int Id)
        {
            return _context.Maestro_pruebas_hist.Where(e => e.maestro_id_paciente == Id && e.maestro_tipo_prueba == 7 && e.maestro_eliminado==false).OrderByDescending(e => e.maestro_fecha).ToList();
        }

        //Guarda el archivo
        [HttpPost]
        [Route("GuardarArchivoAnexo")]
        public IActionResult GuardarArchivoAnexo(IFormFile files, int id_pac, int tipo_prueba, int maestro_id)
        {
            var respuesta = new Respuesta();

            if (files != null)
            {
                if (files.Length > 0)
                {
                    // Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    // Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // Concatenating FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    var objfiles = new Files()
                    {
                        DocumentId = 0,
                        // Name = newFileName,
                        Name = fileName,
                        FileType = fileExtension,
                        CreatedOn = DateTime.Now,
                        files_tipo_prueba = tipo_prueba,
                        files_paciente_id = id_pac
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.DataFiles = target.ToArray();
                    }

                    _context.Files.Add(objfiles);
                    _context.SaveChanges();

                    // Obtener el ID del archivo guardado
                    int imagenId = objfiles.DocumentId;

                    // Actualizar la otra tabla con el ID de la imagen
                    var maestroPruebas = _context.Maestro_pruebas_hist.FirstOrDefault(m => m.maestro_id == maestro_id);
                    if (maestroPruebas != null)
                    {
                        maestroPruebas.maestro_id_imagen = imagenId;
                        _context.SaveChanges();
                    }
                    Console.WriteLine("El archivo se subió correctamente y la tabla Maestro_pruebas fue actualizada.");

                    respuesta.Descripcion = "El archivo se subió correctamente ";
                }
            }

            return Ok(respuesta);
        }



        ////ver archivo 
        ///
        [HttpGet]
        [Route("VerArchivosSnexos/{Id}")]
        public IActionResult ArchivoAnexo(int Id)
        {
            var appfile = _context.Files.FirstOrDefault(x => x.DocumentId == Id);
            if (appfile == null) return NoContent();

            string contentType = appfile.FileType?.ToLower() switch
            {
                ".pdf" => "application/pdf",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".doc" => "application/msword",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".xls" => "application/vnd.ms-excel",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                _ => "application/octet-stream"
            };

            byte[] fileBytes = appfile.DataFiles;

            // ✅ PDF e imágenes → inline (se visualizan en navegador)
            if (contentType.StartsWith("application/pdf") || contentType.StartsWith("image"))
            {
                return new FileContentResult(fileBytes, contentType)
                {
                    FileDownloadName = appfile.Name // el navegador lo respeta si el usuario hace "Guardar como"
                };
            }

            // ✅ Word, Excel, etc. → descarga con nombre original
            Response.Headers["Content-Disposition"] = $"attachment; filename=\"{appfile.Name}\"";
            Response.Headers["Access-Control-Expose-Headers"] = "Content-Disposition";
            return File(fileBytes, contentType, appfile.Name);
        }

        [HttpDelete]
        [Route("DeleteArchivosSnexos/{Id}")]
        public IActionResult Delete(int id)
        {
            var registro = _context.Maestro_pruebas_hist.FirstOrDefault(m => m.maestro_id == id);
            if (registro == null)
                return NotFound();

            registro.maestro_eliminado = true;
            _context.SaveChanges();

            return Ok(new { message = "Registro eliminado correctamente (soft delete)" });
        }

        // ✅ Restaurar
        [HttpPut("Restaurar/{id}")]
        public IActionResult Restaurar(int id)
        {
            var registro = _context.Maestro_pruebas_hist.FirstOrDefault(m => m.maestro_id == id);
            if (registro == null)
                return NotFound();

            registro.maestro_eliminado = false;
            _context.SaveChanges();

            return Ok(new { message = "Registro restaurado correctamente" });
        }

    }
}
