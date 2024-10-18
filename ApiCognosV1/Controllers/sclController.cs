using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
            return _context.v_scl.Where(e=>e.res_id_maestro==Id).ToList();
        }

        [HttpGet]
        [Route("testSCLTotal/{Id}")]
        public IActionResult GetCount(int Id)
        {
            int totalResp = _context.v_scl.Where(x=>x.res_id_maestro == Id).AsEnumerable().Sum(row => row.res_respuesta);
            return Ok(totalResp);
        }

        [HttpGet]
        [Route("MaestroSCLList/{Id}")]
        public IEnumerable<Maestro_pruebas> MaestroSCLList(int Id)
        {
            return _context.Maestro_pruebas.Where(e => e.maestro_id_paciente == Id && e.maestro_tipo_prueba == 2).ToList();
        }

        [HttpGet]
        [Route("MaestroHistSCLList/{Id}")]
        public IEnumerable<Maestro_pruebas_hist> MaestroHistSCLList(int Id)
        {
            return _context.Maestro_pruebas_hist.Where(e => e.maestro_id_paciente == Id && e.maestro_tipo_prueba == 2).ToList();
        }


        //Ruta para insertar maestro de pruebas
        [HttpPost]
        [Route("MaestroSCL")]
        public IActionResult InsertMaestroSCL(int maestro_id_paciente)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            int idx = 0;
            //var respuesta = new Respuesta();
            if (maestro_id_paciente>0)
            {
                Console.WriteLine(maestro_id_paciente);
                var objfiles = new Maestro_pruebas()
                {
                    maestro_id = 0,
                    //Name = newFileName,
                    maestro_fecha = enteredDate,
                    maestro_tipo_prueba = 2,
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
        [Route("MaestroHistSCL")]
        public IActionResult InsertMaestroHistSCL(int maestro_id_paciente, string fecha,string observ)
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
                    maestro_tipo_prueba = 2,
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
                            res_id_paciente = resp[i].res_id_paciente,
                            res_id_maestro= resp[i].res_id_maestro

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

        //Modificaciones para resultados
        //Se eliminan los id y se vuelven ainsertar para mostrarse en el informe
        [HttpDelete]
        [Route("AsignarPruebasScl")]
        public IActionResult DeleteMostrarSCL(string ids, int prueba, int exp, string imagen_id)
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


        [HttpPost]
        [Route("GuardarImagenScl")]
        public IActionResult Index(IFormFile files, int id_pac, int tipo_prueba,int maestro_id)
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
                    var maestroPruebas = _context.Maestro_pruebas.FirstOrDefault(m => m.maestro_id == maestro_id );
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
        [Route("GuardarImagenSclHist")]
        public IActionResult GuardarImagenSclHist(IFormFile files, int id_pac, int tipo_prueba,int maestro_id)
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
                    var maestroPruebas = _context.Maestro_pruebas_hist.FirstOrDefault(m => m.maestro_id == maestro_id );
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

        ////ver imagen 

        ////ver imagen 
        ///
        [HttpGet]
        [Route("VerArchivosSCL/{Id}")]
        public IActionResult watchSCL(int Id)
        {
            Files forum = new Files();//this model is used to "join" various
                                      //models

            //get the data from the different tables with the id sending from the MVC controller
            var appfile = _context.Files.Where(x => x.DocumentId== Id).FirstOrDefault();

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
        [Route("ArchivosSCLInforme/{IdPac}")]
        public IActionResult ImagenesSCL(int IdPac)
        {
            List<mostrar_exp> MostrarExp = _context.mostrar_exp.Where(x => x.most_tipo_prueba == 2 && x.most_expediente == IdPac).ToList();
            List<Files> result = new List<Files>();
            if (MostrarExp.Count() > 0) {
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
