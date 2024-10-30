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

        [HttpGet]
        [Route("MaestroIsraList/{Id}")]
        public IEnumerable<Maestro_pruebas> MaestroIsraList(int Id)
        {
            return _context.Maestro_pruebas.Where(e => e.maestro_id_paciente == Id && e.maestro_tipo_prueba == 4).ToList();
        }

        [HttpGet]
        [Route("MaestroHistIsraList/{Id}")]
        public IEnumerable<Maestro_pruebas_hist> MaestroHistIsraList(int Id)
        {
            return _context.Maestro_pruebas_hist.Where(e => e.maestro_id_paciente == Id && e.maestro_tipo_prueba == 4).OrderByDescending(e => e.maestro_fecha).ToList();
        }

        //Ruta para insertar maestro de pruebas
        [HttpPost]
        [Route("MaestroIsra")]
        public IActionResult InsertMaestroIsra(int maestro_id_paciente)
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
                    maestro_tipo_prueba = 4,
                    maestro_id_paciente = maestro_id_paciente

                };
                _context.Maestro_pruebas.Add(objfiles);
                _context.SaveChanges();
                idx = objfiles.maestro_id;

            }

            return Ok(new { id = idx });
        }

        //Ruta para insertar maestro de pruebas històrico
        [HttpPost]
        [Route("MaestroHistIsra")]
        public IActionResult InsertMaestroHistIsra(int maestro_id_paciente, string fecha,string observ)
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
                    maestro_tipo_prueba = 4,
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
            return _context.v_israC.Where(e => e.res_id_maestro == Id).ToList();
        }

        [HttpGet]
        [Route("testIsraRespuestasF/{Id}")]
        public IEnumerable<v_israF_x> GetRespuestasF(int Id)
        {
            return _context.v_israF.Where(e => e.res_id_maestro == Id).ToList();
        }

        [HttpGet]
        [Route("testIsraRespuestasM/{Id}")]
        public IEnumerable<v_israM_x> GetRespuestasM(int Id)
        {
            return _context.v_israM.Where(e => e.res_id_maestro == Id).ToList();
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
                            //res_observacion = resp[i].res_observacion,
                            //res_sum = resp[i].res_sum,
                            res_id_paciente = resp[i].res_id_paciente,
                            res_id_maestro = resp[i].res_id_maestro,
                            
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
                            //res_observacion = resp[i].res_observacion,
                            //res_sum = resp[i].res_sum,
                            res_id_paciente = resp[i].res_id_paciente,
                            res_id_maestro = resp[i].res_id_maestro,
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
                            //res_observacion = resp[i].res_observacion,
                            //res_sum = resp[i].res_sum,
                            res_id_paciente = resp[i].res_id_paciente,
                            res_id_maestro = resp[i].res_id_maestro,
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

        //Modificaciones para resultados
        //Se eliminan los id y se vuelven ainsertar para mostrarse en el informe
        [HttpDelete]
        [Route("AsignarPruebasIsra")]
        public IActionResult DeleteMostrarIsra(string ids, int prueba, int exp, string imagen_id)
        {
            var respuesta = new Respuesta();

            // Primero se eliminan los id maestros que ya estén asignados
            var datos = _context.mostrar_exp.Where(x => x.most_tipo_prueba == prueba && x.most_expediente == exp).ToList();

            for (int i = 0; i < datos.Count; i++)
            {
                _context.mostrar_exp.Remove(datos[i]);
                _context.SaveChanges();
            }

            // Se guardan los id maestros que se quieren mostrar en el expediente
            if (ids != null && imagen_id != null)
            {
                int[] numbers = ids.Split(',')
                           .Select(int.Parse)
                           .ToArray();

                int[] id_img = imagen_id.Split(',')
                           .Select(int.Parse)
                           .ToArray();

                // Asegurarse de que ambos arrays tengan la misma longitud
                if (numbers.Length != id_img.Length)
                {
                    respuesta.Descripcion = "Los IDs y los IDs de imagen no coinciden en número.";
                    return BadRequest(respuesta);
                }

                // Recorrer ambos arrays en paralelo
                for (int i = 0; i < numbers.Length; i++)
                {
                    int number = numbers[i];
                    int imageId = id_img[i];

                    var objfiles = new mostrar_exp()
                    {
                        most_id = 0,
                        most_id_maestro = number,
                        most_tipo_prueba = prueba,
                        most_expediente = exp,
                        most_id_imagen = imageId
                    };

                    _context.mostrar_exp.Add(objfiles);
                    _context.SaveChanges();
                }

                respuesta.Descripcion = "Pruebas asignadas a expediente correctamente";
            }
            else
            {
                respuesta.Descripcion = "IDs o IDs de imagen no proporcionados.";
                return BadRequest(respuesta);
            }

            return Ok(respuesta);
        }

        //Cambios en los resultados isra

        [HttpPost]
        [Route("GuardarImagenIsra")]
        public IActionResult Index(IFormFile files, int id_pac, int tipo_prueba, int maestro_id)
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
                    var maestroPruebas = _context.Maestro_pruebas.FirstOrDefault(m => m.maestro_id == maestro_id);
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

        [HttpPost]
        [Route("GuardarImagenIsraHist")]
        public IActionResult GuardarImagenIsraHist(IFormFile files, int id_pac, int tipo_prueba, int maestro_id)
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
                    Console.WriteLine("✅El archivo se subió correctamente y la tabla Maestro_pruebas_hist fue actualizada.");

                    respuesta.Descripcion = "El archivo se subió correctamente ";
                }
            }

            return Ok(respuesta);
        }

        ////ver imagen 
        ///
        [HttpGet]
        [Route("VerArchivosIsra/{Id}")]
        public IActionResult watchIsra(int Id)
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
        ///////Cargar archivos en el informe

        [HttpGet]
        [Route("ArchivosIsraInforme/{IdPac}")]
        public IActionResult ImagenesIsra(int IdPac)
        {
            List<mostrar_exp> MostrarExp = _context.mostrar_exp.Where(x => x.most_tipo_prueba == 4 && x.most_expediente == IdPac).ToList();
            List<Files> result = new List<Files>();
            if (MostrarExp.Count() > 0)
            {
                // Obtener solo los IDs
                var ids = MostrarExp.Select(f => f.most_id_imagen).ToList();

                // Concatenar los IDs en una cadena separada por comas
                string concatenatedIds = string.Join(",", ids);

                // Convertir la cadena de IDs en un array de enteros
                int[] idArray = concatenatedIds.Split(',').Select(int.Parse).ToArray();

                // Usar el array en la consulta LINQ con IN
                 result = _context.Files
                    .Where(x => idArray.Contains(x.DocumentId))
                    .ToList();
            }
     

            return Ok(result);


        }
        /////////////////////////////////
    }
}
