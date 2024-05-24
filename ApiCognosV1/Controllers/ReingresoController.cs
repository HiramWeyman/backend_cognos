using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ApiCognosV1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReingresoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ReingresoController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;
        }

        [HttpPost]
        [Route("insertFreingreso")]
        public IActionResult insertFreingreso([FromBody] Freingreso resp)
        {
            var dateString = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enterDate = DateTime.Parse(dateString);

            var respuesta = new Respuesta();
            if (resp != null)
            {
                Console.WriteLine(resp);
                var objfiles = new Freingreso()
                {
                    Idrei = 0,
                    Id_pac_rei = resp.Id_pac_rei,
                    fecha_rei = resp.fecha_rei,
                    usuario_rei = resp.usuario_rei,
                    fecha_creacion_rei = enterDate
                };
                try
                {
                    _context.Freingreso.Add(objfiles);
                    _context.SaveChanges();
                    respuesta.Descripcion = "Fecha guardada correctamente";
                }
                catch (Exception e)
                {
                    throw e.InnerException;
                }


            }

            return Ok(respuesta);
        }


        [HttpGet]
        [Route("getFreingreso/{Id}")]
        public IEnumerable<Freingreso> getFreingreso(int Id)
        {
            return _context.Freingreso.Where(e => e.Id_pac_rei == Id).OrderBy(p=>p.fecha_rei).ToList();
        }

        [HttpDelete]
        [Route("deleteFechareingreso/{Id}")]
        public IActionResult deleteGrupo(int Id)
        {
            //return _context.Usuarios.Where(e => e.maestro_id_paciente == Id && e.maestro_tipo_prueba == 6).ToList();
            Freingreso data = _context.Freingreso.Where(x => x.Idrei == Id).FirstOrDefault();

            var respuesta = new Respuesta();

            if (data == null)
            {
                respuesta.Descripcion = "Fecha No encontrada";
            }
            else
            {
                _context.Freingreso.Remove(data);
                _context.SaveChanges();
                respuesta.Descripcion = "Fecha eliminada correctamente";

            }

            return Ok(respuesta);

        }



    }
}
