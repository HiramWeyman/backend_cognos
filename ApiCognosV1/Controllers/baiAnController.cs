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
        [Route("MaestroBAIanList/{Id}")]
        public IEnumerable<Maestro_pruebas> MaestroBAIanList(int Id)
        {
            return _context.Maestro_pruebas.Where(e => e.maestro_id_paciente == Id && e.maestro_tipo_prueba == 1).ToList();
        }


        //Ruta para insertar maestro de pruebas
        [HttpPost]
        [Route("MaestroBAIan")]
        public IActionResult InsertMaestroBAIan(int maestro_id_paciente)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            int idx = 0;
            //var respuesta = new Respuesta();
            if (maestro_id_paciente > 0)
            {
                Console.WriteLine(maestro_id_paciente);
                var objfiles = new Maestro_pruebas()
                {
                    maestro_id = 0,
                    //Name = newFileName,
                    maestro_fecha = enteredDate,
                    maestro_tipo_prueba = 1,
                    maestro_id_paciente = maestro_id_paciente

                };
                _context.Maestro_pruebas.Add(objfiles);
                _context.SaveChanges();
                idx = objfiles.maestro_id;

            }

            return Ok(new { id = idx });
        }

        [HttpGet]
        [Route("testBAIanRespuestas/{Id}")]
        public IEnumerable<v_baian_x> GetRespuestas(int Id)
        {
            return _context.v_baian.Where(e => e.res_id_maestro == Id).ToList();
        }

        [HttpGet]
        [Route("testBAIanTotal/{Id}")]
        public IActionResult GetCount(int Id)
        {
            int totalResp = _context.v_baian.Where(x => x.res_id_maestro == Id).AsEnumerable().Sum(row => row.res_respuesta);
            return Ok(totalResp);
        }

        [HttpPost]
        [Route("testBAIanResp")]
        public IActionResult InsertRespBAIan(CrearRespBAIan[] resp)
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
                            res_id_paciente = resp[i].res_id_paciente,
                            res_id_maestro = resp[i].res_id_maestro

                        };



                        _context.RespBAIan.Add(objfiles);
                        _context.SaveChanges();
                    }

                    respuesta.Descripcion = "Respuestas gurdadas correctamente";

                }
            }

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("deleteBAIanResp/{Id}")]
        public IActionResult DeleteBAIanResp(int Id)
        {
            var respuesta = new Respuesta();

            //get the data from the different tables with the id sending from the MVC controller
            var resp = _context.RespBAIan.Where(x => x.res_id_paciente == Id).ToList();

            if (resp == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                for (int i = 0; i < resp.Count; i++)
                {
                    _context.RespBAIan.Remove(resp[i]);
                    _context.SaveChanges();
                }

                respuesta.Descripcion = "Respuestas eliminadas correctamente";
            }
            return Ok(respuesta);
        }
    }
}
