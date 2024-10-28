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

        [HttpGet]
        [Route("MaestroHistBDIDPList/{Id}")]
        public IEnumerable<Maestro_pruebas_hist> MaestroHistBDIDPList(int Id)
        {
            return _context.Maestro_pruebas_hist.Where(e => e.maestro_id_paciente == Id && e.maestro_tipo_prueba == 3).OrderByDescending(e => e.maestro_fecha).ToList();
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


        [HttpPost]
        [Route("GuardarImagenBDIdpHist")]
        public IActionResult GuardarImagenBDIdpHist(IFormFile files, int id_pac, int tipo_prueba, int maestro_id)
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
                    Console.WriteLine("✅ El archivo se subió correctamente y la tabla Maestro_pruebas_hist fue actualizada.");

                    respuesta.Descripcion = "El archivo se subió correctamente ";
                }
            }

            return Ok(respuesta);
        }
        
        ////ver imagen 
        ///
        [HttpGet]
        [Route("VerArchivosBDIdp/{Id}")]
        public IActionResult watchSCID(int Id)
        {
            Files forum = new Files();//this model is used to "join" various
                                      //models

            //get the data from the different tables with the id sending from the MVC controller
            var appfile = _context.Files.Where(x => x.DocumentId == Id).FirstOrDefault();

            if (appfile == null)
            {
                return NoContent();
            }
            else
            {
                //Content data from the post

                forum.DocumentId = appfile.DocumentId;
                forum.Name = appfile.Name;//the text part
                forum.FileType = appfile.FileType;
                forum.DataFiles = appfile.DataFiles;//the image
                forum.files_tipo_prueba = appfile.files_tipo_prueba;
                forum.files_paciente_id = appfile.files_paciente_id;
                return Ok(forum);
            }
        }

        //Ruta para insertar maestro de pruebas històrico
        [HttpPost]
        [Route("MaestroHistBDIdp")]
        public IActionResult InsertMaestroHistBDIdp(int maestro_id_paciente, string fecha,string observ)
        {
            DateTime enteredDate = DateTime.Parse(fecha);
            int idx = 0;
            //var respuesta = new Respuesta();
            if (maestro_id_paciente > 0)
            {
                Console.WriteLine("🚨MAESTROIDPACIENTE -->" + maestro_id_paciente);
                var objfiles = new Maestro_pruebas_hist()
                {
                    maestro_id = 0,
                    //Name = newFileName,
                    maestro_fecha = enteredDate,
                    maestro_tipo_prueba = 3,
                    maestro_id_paciente = maestro_id_paciente,
                    maestro_id_imagen = 0,
                    maestro_observacion= observ

                };
                _context.Maestro_pruebas_hist.Add(objfiles);
                _context.SaveChanges();
                idx = objfiles.maestro_id;

            }

            return Ok(new { id = idx });
        }


    }


}
