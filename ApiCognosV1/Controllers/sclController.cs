using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XAct;
using XAct.Library.Settings;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sclController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public sclController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;
           
        }

        [HttpGet]
        [Route("testSCL")]
        public IEnumerable<TestSCL> GetPreguntas()
        {
            return _context.TestSCL.ToList();
        }

        [HttpGet]
        [Route("testSCLRespuestas/{Id}")]
        public IEnumerable<v_scl_x> GetRespuestas(int Id)
        {
            return _context.v_scl.Where(e=>e.res_id_paciente==Id).ToList();
        }

        [HttpGet]
        [Route("testSCLTotal/{Id}")]
        public IActionResult GetCount(int Id)
        {
            int totalResp = _context.v_scl.Where(x=>x.res_id_paciente==Id).AsEnumerable().Sum(row => row.res_respuesta);
            return Ok(totalResp);
        }





        [HttpPost]
        [Route("testSCLResp")]
        public IActionResult InsertRespSCL(CrearRespSCL[] resp)
        {
            var respuesta = new Respuesta();
            if (resp != null)
            {
                if (resp.Length > 0)
                {
                    //Getting FileName

                    for (int i=0;i< resp.Length;i++) {

                        Console.WriteLine(resp[i]);
                        var objfiles = new RespSCL()
                        {
                            res_id = 0,
                            //Name = newFileName,
                            res_pregunta = resp[i].res_pregunta,
                            res_respuesta = resp[i].res_respuesta,
                            res_id_paciente = resp[i].res_id_paciente

                        };



                        _context.RespSCL.Add(objfiles);
                        _context.SaveChanges();
                    }
                   
                    respuesta.Descripcion = "Respuestas gurdadas correctamente";

                }
            }

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("deleteSCLResp/{Id}")]
        public IActionResult DeleteSCLResp(int Id)
        {
            var respuesta = new Respuesta();

            //get the data from the different tables with the id sending from the MVC controller
            var resp = _context.RespSCL.Where(x => x.res_id_paciente == Id).ToList();

            if (resp == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                for (int i = 0; i < resp.Count; i++)
                {
                    _context.RespSCL.Remove(resp[i]);
                    _context.SaveChanges();
                }

                respuesta.Descripcion = "Respuestas eliminadas correctamente";
            }
            return Ok(respuesta);
        }

    }
}
