using ApiCognosV1.Data;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bdiDpController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public bdiDpController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;

        }

        //[HttpGet]
        //[Route("testBDIdp")]
        //public IEnumerable<TestBDI_Inv_Dp> GetPreguntas()
        //{
        //    return _context.TestBDI_Inv_Dp.ToList();
        //}

        [HttpGet]
        [Route("MaestroBDIDPList/{Id}")]
        public IEnumerable<Maestro_pruebas> MaestroBDIDPList(int Id)
        {
            return _context.Maestro_pruebas.Where(e => e.maestro_id_paciente == Id && e.maestro_tipo_prueba == 3).ToList();
        }


        //Ruta para insertar maestro de pruebas
        [HttpPost]
        [Route("MaestroBDIdp")]
        public IActionResult InsertMaestroBDIdp(int maestro_id_paciente)
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
                    maestro_tipo_prueba = 3,
                    maestro_id_paciente = maestro_id_paciente,


                };
                _context.Maestro_pruebas.Add(objfiles);
                _context.SaveChanges();
                idx = objfiles.maestro_id;

            }

            return Ok(new { id = idx });
        }


        [HttpGet]
        [Route("testBDIdpRespuestas/{Id}")]
        public IEnumerable<v_bdidp_x> GetRespuestas(int Id)
        {
            return _context.v_bdidp.Where(e => e.res_id_maestro == Id).ToList();
        }



        [HttpGet]
        [Route("testBDIdpTotal/{Id}")]
        public IActionResult GetTotalResp(int Id)
        {
            IEnumerable<v_bdidp_x> coleccion = _context.v_bdidp.Where(e => e.res_id_maestro == Id).ToList();
            int sumaTotal = 0;

            foreach (var item in coleccion)
            {
                // Extracción de números enteros de res_respuesta
                var enteros = Regex.Matches(item.res_respuesta, @"-?\d+")
                                   .Cast<Match>()
                                   .Select(m => int.Parse(m.Value))
                                   .ToList();

                // Sumar los números extraídos
                sumaTotal += enteros.Sum();
            }

            // Imprimir la suma total de los números enteros
            Console.WriteLine("La suma total de los números enteros en res_respuesta es: " + sumaTotal);

            return Ok(sumaTotal);
        }


        //[HttpGet]
        //[Route("testBDIdpTotal/{Id}")]
        //public IActionResult GetCount(int Id)
        //{
        //    int totalResp = _context.v_bdidp.Where(x => x.res_id_paciente == Id).AsEnumerable().Sum(row => row.res_respuesta);
        //    return Ok(totalResp);
        //}

        [HttpPost]
        [Route("testBDIdpResp")]
        public IActionResult InsertRespBDI(CrearRespBDIdp[] resp)
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
                        var objfiles = new RespBDIdp()
                        {
                            res_id = 0,
                            //Name = newFileName,
                            res_pregunta = resp[i].res_pregunta,
                            res_respuesta = resp[i].res_respuesta,
                            res_id_paciente = resp[i].res_id_paciente,
                            res_id_maestro = resp[i].res_id_maestro
                        };



                        _context.RespBDIdp.Add(objfiles);
                        _context.SaveChanges();
                    }

                    respuesta.Descripcion = "Respuestas gurdadas correctamente";

                }
            }

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("deleteBDIdpResp/{Id}")]
        public IActionResult DeleteRespBDI(int Id)
        {
            var respuesta = new Respuesta();

            //get the data from the different tables with the id sending from the MVC controller
            var resp = _context.RespBDIdp.Where(x => x.res_id_paciente == Id).ToList();

            if (resp == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                for (int i=0;i< resp.Count;i++) {
                    _context.RespBDIdp.Remove(resp[i]);
                    _context.SaveChanges();
                }
               
                respuesta.Descripcion = "Respuestas eliminadas correctamente";
            }
            return Ok(respuesta);
        }
    }
}
