using ApiCognosV1.Data;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class baiAnController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public baiAnController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;

        }

        [HttpGet]
        [Route("testBAIan")]
        public IEnumerable<TestBAI_Inv_An> GetPreguntas()
        {
            return _context.TestBAI_Inv_An.ToList();
        }

        [HttpGet]
        [Route("testBAIanRespuestas/{Id}")]
        public IEnumerable<v_baian_x> GetRespuestas(int Id)
        {
            return _context.v_baian.Where(e => e.res_id_paciente == Id).ToList();
        }

        [HttpGet]
        [Route("testBAIanTotal/{Id}")]
        public IActionResult GetCount(int Id)
        {
            int totalResp = _context.v_baian.Where(x => x.res_id_paciente == Id).AsEnumerable().Sum(row => row.res_respuesta);
            return Ok(totalResp);
        }

        [HttpPost]
        [Route("testBAIanResp")]
        public IActionResult InsertRespSCL(CrearRespBAIan[] resp)
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
                        var objfiles = new RespBAIan()
                        {
                            res_id = 0,
                            //Name = newFileName,
                            res_pregunta = resp[i].res_pregunta,
                            res_respuesta = resp[i].res_respuesta,
                            res_id_paciente = resp[i].res_id_paciente

                        };



                        _context.RespBAIan.Add(objfiles);
                        _context.SaveChanges();
                    }

                    respuesta.Descripcion = "Respuestas gurdadas correctamente";

                }
            }

            return Ok(respuesta);
        }
    }
}
