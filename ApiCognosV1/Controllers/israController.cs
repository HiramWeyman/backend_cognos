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
    public class israController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public israController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;

        }

        //[HttpGet]
        //[Route("TestSCID")]
        //public IEnumerable<TestSCID> GetPreguntas()
        //{
        //    return _context.TestSCID.ToList();
        //}

        [HttpGet]
        [Route("testIsraRespuestasC/{Id}")]
        public IEnumerable<v_israC_x> GetRespuestasC(int Id)
        {
            return _context.v_israC.Where(e => e.res_id_paciente == Id).ToList();
        }

        [HttpGet]
        [Route("testIsraRespuestasF/{Id}")]
        public IEnumerable<v_israF_x> GetRespuestasF(int Id)
        {
            return _context.v_israF.Where(e => e.res_id_paciente == Id).ToList();
        }

        [HttpGet]
        [Route("testIsraRespuestasM/{Id}")]
        public IEnumerable<v_israM_x> GetRespuestasM(int Id)
        {
            return _context.v_israM.Where(e => e.res_id_paciente == Id).ToList();
        }


        [HttpPost]
        [Route("TestISRARespC")]
        public IActionResult InsertRespIsraC(CrearRespIsraC[] resp)
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
                        var objfiles = new RespIsraC()
                        {
                            res_id = 0,
                            //Name = newFileName,
                            res_pregunta = resp[i].res_pregunta,
                            res_respuesta1 = resp[i].res_respuesta1,
                            res_respuesta2 = resp[i].res_respuesta2,
                            res_respuesta3 = resp[i].res_respuesta3,
                            res_respuesta4 = resp[i].res_respuesta4,
                            res_respuesta5 = resp[i].res_respuesta5,
                            res_respuesta6 = resp[i].res_respuesta6,
                            res_respuesta7 = resp[i].res_respuesta7,
                            res_observacion = resp[i].res_observacion,
                            res_sum = resp[i].res_sum,
                            res_id_paciente = resp[i].res_id_paciente
                         };



                        _context.RespIsraC.Add(objfiles);
                        _context.SaveChanges();
                    }

                    respuesta.Descripcion = "Respuestas gurdadas correctamente";

                }
            }

            return Ok(respuesta);
        }


        [HttpPost]
        [Route("TestISRARespF")]
        public IActionResult InsertRespIsraF(CrearRespIsraF[] resp)
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
                        var objfiles = new RespIsraF()
                        {
                            res_id = 0,
                            //Name = newFileName,
                            res_pregunta = resp[i].res_pregunta,
                            res_respuesta1 = resp[i].res_respuesta1,
                            res_respuesta2 = resp[i].res_respuesta2,
                            res_respuesta3 = resp[i].res_respuesta3,
                            res_respuesta4 = resp[i].res_respuesta4,
                            res_respuesta5 = resp[i].res_respuesta5,
                            res_respuesta6 = resp[i].res_respuesta6,
                            res_respuesta7 = resp[i].res_respuesta7,
                            res_respuesta8 = resp[i].res_respuesta8,
                            res_respuesta9 = resp[i].res_respuesta9,
                            res_respuesta10 = resp[i].res_respuesta10,
                            res_observacion = resp[i].res_observacion,
                            res_sum = resp[i].res_sum,
                            res_id_paciente = resp[i].res_id_paciente
                        };



                        _context.RespIsraF.Add(objfiles);
                        _context.SaveChanges();
                    }

                    respuesta.Descripcion = "Respuestas gurdadas correctamente";

                }
            }

            return Ok(respuesta);
        }


        [HttpPost]
        [Route("TestISRARespM")]
        public IActionResult InsertRespIsraM(CrearRespIsraM[] resp)
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
                        var objfiles = new RespIsraM()
                        {
                            res_id = 0,
                            //Name = newFileName,
                            res_pregunta = resp[i].res_pregunta,
                            res_respuesta1 = resp[i].res_respuesta1,
                            res_respuesta2 = resp[i].res_respuesta2,
                            res_respuesta3 = resp[i].res_respuesta3,
                            res_respuesta4 = resp[i].res_respuesta4,
                            res_respuesta5 = resp[i].res_respuesta5,
                            res_respuesta6 = resp[i].res_respuesta6,
                            res_respuesta7 = resp[i].res_respuesta7,
                            res_observacion = resp[i].res_observacion,
                            res_sum = resp[i].res_sum,
                            res_id_paciente = resp[i].res_id_paciente
                        };



                        _context.RespIsraM.Add(objfiles);
                        _context.SaveChanges();
                    }

                    respuesta.Descripcion = "Respuestas gurdadas correctamente";

                }
            }

            return Ok(respuesta);
        }



        [HttpDelete]
        [Route("deleteIsraResp/{Id}")]
        public IActionResult DeleteSCIDResp(int Id)
        {
            var respuesta = new Respuesta();

            //get the data from the different tables with the id sending from the MVC controller
            var resp = _context.RespIsraC.Where(x => x.res_id_paciente == Id).ToList();
            var resp2 = _context.RespIsraF.Where(x => x.res_id_paciente == Id).ToList();
            var resp3 = _context.RespIsraM.Where(x => x.res_id_paciente == Id).ToList();

            if (resp == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                for (int i = 0; i < resp.Count; i++)
                {
                    _context.RespIsraC.Remove(resp[i]);
                    _context.SaveChanges();
                }

                //respuesta.Descripcion = "Respuestas eliminadas correctamente";
            }
            if (resp2 == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                for (int i = 0; i < resp2.Count; i++)
                {
                    _context.RespIsraF.Remove(resp2[i]);
                    _context.SaveChanges();
                }

                //respuesta.Descripcion = "Respuestas eliminadas correctamente";
            }
            if (resp3 == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                for (int i = 0; i < resp3.Count; i++)
                {
                    _context.RespIsraM.Remove(resp3[i]);
                    _context.SaveChanges();
                }

                respuesta.Descripcion = "Respuestas eliminadas correctamente";
            }
            return Ok(respuesta);
        }
    }
}
