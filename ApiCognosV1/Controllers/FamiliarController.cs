using ApiCognosV1.Data;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FastReport.Utils;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliarController : ControllerBase
    {
        private readonly ApplicationDBContext _context;


        public FamiliarController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;

        }

        [HttpGet]
        [Route("getFamiliar/{Id}")]
        public IActionResult getFamiliar(int Id)
        {
            var respuesta = new Respuesta();
            EstructuraFami resp = new EstructuraFami();

            //get the data from the different tables with the id sending from the MVC controller
            resp = _context.EstructuraFami.Where(x => x.fam_id == Id).FirstOrDefault();

            return Ok(resp);

        }


        [HttpGet]
        [Route("getFamiliarList/{Id}")]
        public IActionResult getFamiliarList(string Id)
        {
        
            //get the data from the different tables with the id sending from the MVC controller
            List<EstructuraFami> resp = _context.EstructuraFami.Where(x => x.fam_llave_pac == Id).ToList();
            return Ok(resp);

        }

        [HttpPost]
        [Route("insertaFam")]
        public IActionResult insertFam(CrearEstructuraFam resp)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            var respuesta = new Respuesta();

            if (resp != null)
            {
                Console.WriteLine(resp);
                var objfiles = new EstructuraFami()
                {
                    fam_id = 0,
                    //Name = newFileName,
                    fam_nombre = resp.fam_nombre,
                    fam_edad = resp.fam_edad,
                    fam_parentesco = resp.fam_parentesco,
                    fam_ocupacion = resp.fam_ocupacion,
                    fam_dependientes= resp.fam_dependientes,
                    fam_fecha_captura = enteredDate,
                    fam_llave_pac = resp.fam_llave_pac

                };



                _context.EstructuraFami.Add(objfiles);
                _context.SaveChanges();
                respuesta.Descripcion = "Familar registrado correctamente";
            }

            return Ok(respuesta);
        }

        [HttpPatch]
        [Route("actualizaFam/{Id}")]
        public IActionResult actualizaFam(int Id,[FromBody] EstructuraFamDto fam)
        {
            var respuesta = new Respuesta();
            EstructuraFami resp = new EstructuraFami();

            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);

            //get the data from the different tables with the id sending from the MVC controller
            resp = _context.EstructuraFami.Where(x => x.fam_id == Id).FirstOrDefault();

            if (resp == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                resp.fam_nombre = fam.fam_nombre;
                resp.fam_edad = fam.fam_edad;
                resp.fam_parentesco = fam.fam_parentesco;
                resp.fam_ocupacion = fam.fam_ocupacion;
                resp.fam_dependientes = fam.fam_dependientes;
                resp.fam_fecha_modificacion = enteredDate;
                _context.EstructuraFami.Update(resp);
                _context.SaveChanges();

                respuesta.Descripcion = "Familiar Actualizado correctamente";
            }
            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("eliminaFam/{Id}")]
        public IActionResult eliminaFam(int Id)
        {
            var respuesta = new Respuesta();
            EstructuraFami resp = new EstructuraFami();

            //get the data from the different tables with the id sending from the MVC controller
             resp = _context.EstructuraFami.Where(x => x.fam_id== Id).FirstOrDefault();

            if (resp == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                _context.EstructuraFami.Remove(resp);
                _context.SaveChanges();

                respuesta.Descripcion = "Familiar Eliminado correctamente";
            }
            return Ok(respuesta);
        }
    }
}
