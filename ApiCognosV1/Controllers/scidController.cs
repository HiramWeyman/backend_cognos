using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class scidController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public scidController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;

        }

        [HttpGet]
        [Route("TestSCID")]
        public IEnumerable<TestSCID> GetPreguntas()
        {
            return _context.TestSCID.ToList();
        }

        [HttpGet]
        [Route("testSCIDRespuestas/{Id}")]
        public IEnumerable<v_scid_x> GetRespuestas(int Id)
        {
            return _context.v_scid.Where(e => e.res_id_paciente == Id).ToList();
        }


        [HttpPost]
        [Route("TestSCIDResp")]
        public IActionResult InsertRespSCID(CrearRespSCID[] resp)
        {
            var respuesta = new Respuesta();
            if (resp != null)
            {
                if (resp.Length > 0)
                {
                    //Getting FileName

                    for (int i = 0; i < resp.Length; i++)
                    {

                        Console.WriteLine(resp[i]);
                        var objfiles = new RespSCID()
                        {
                            res_id = 0,
                            //Name = newFileName,
                            res_pregunta = resp[i].res_pregunta,
                            res_respuesta = resp[i].res_respuesta,
                            res_id_paciente = resp[i].res_id_paciente

                        };



                        _context.RespSCID.Add(objfiles);
                        _context.SaveChanges();
                    }

                    respuesta.Descripcion = "Respuestas gurdadas correctamente";

                }
            }

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("deleteSCIDResp/{Id}")]
        public IActionResult DeleteSCIDResp(int Id)
        {
            var respuesta = new Respuesta();

            //get the data from the different tables with the id sending from the MVC controller
            var resp = _context.RespSCID.Where(x => x.res_id_paciente == Id).ToList();

            if (resp == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                for (int i = 0; i < resp.Count; i++)
                {
                    _context.RespSCID.Remove(resp[i]);
                    _context.SaveChanges();
                }

                respuesta.Descripcion = "Respuestas eliminadas correctamente";
            }
            return Ok(respuesta);
        }
    }
}
