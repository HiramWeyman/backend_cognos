using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XAct;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivosController : ControllerBase
    {
        //private readonly ICreenciasRepositorio _pacRepo;
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public ArchivosController( IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Index(IFormFile files,int id_pac,int tipo_prueba)
        {
            var respuesta = new Respuesta();
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    var objfiles = new Files()
                    {
                        DocumentId = 0,
                        //Name = newFileName,
                        Name= fileName,
                        FileType = fileExtension,
                        CreatedOn = DateTime.Now,
                        files_tipo_prueba=tipo_prueba,
                        files_paciente_id= id_pac
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.DataFiles = target.ToArray();
                    }

                    _context.Files.Add(objfiles);
                    _context.SaveChanges();
                    respuesta.Descripcion = "El archivo se subio correctamente";

                }
            }
           
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("ArchivosSCL/{IdPac}")]
        public IActionResult watchSCL(int IdPac)
        {
            Files forum = new Files();//this model is used to "join" various
                                                            //models

            //get the data from the different tables with the id sending from the MVC controller
            var appfile = _context.Files.Where(x => x.files_tipo_prueba==1 && x.files_paciente_id == IdPac).FirstOrDefault();

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

        [HttpGet]
        [Route("ArchivosSCID/{IdPac}")]
        public IActionResult watchSCID(int IdPac)
        {
            Files forum = new Files();//this model is used to "join" various
                                      //models

            //get the data from the different tables with the id sending from the MVC controller
            var appfile = _context.Files.Where(x => x.files_tipo_prueba == 2 && x.files_paciente_id == IdPac).FirstOrDefault();

            if (appfile==null) {
                return NoContent();
            }
            else {
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

        [HttpGet]
        [Route("ArchivosDiagrama/{IdPac}")]
        public IActionResult watchDiagrama(int IdPac)
        {
            Files forum = new Files();//this model is used to "join" various
                                      //models

            //get the data from the different tables with the id sending from the MVC controller
            var appfile = _context.Files.Where(x => x.files_tipo_prueba == 3 && x.files_paciente_id == IdPac).FirstOrDefault();

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

        [HttpDelete]
        [Route("Archivos/{IdPost}")]
        public IActionResult watchDelete(int IdPost)
        {
            var respuesta = new Respuesta();
            Files forum = new Files();//this model is used to "join" various
                                      //models

            //get the data from the different tables with the id sending from the MVC controller
            var appfile = _context.Files.Where(x => x.DocumentId == IdPost).FirstOrDefault();

            if (appfile == null)
            {
                respuesta.Descripcion = "El archivo no se encontro";
                return Ok(respuesta);
            }
            else {
                _context.Files.Remove(appfile);
                _context.SaveChanges();
                respuesta.Descripcion = "El archivo se elimino correctamente";
            }
            return Ok(respuesta);
        }


        [HttpPatch]
        [Route("Archivos/{IdPost}")]
        public IActionResult watchUpdate(int IdPost, IFormFile files)
        {
            var respuesta = new Respuesta();

            var appfile = _context.Files.Where(x => x.DocumentId == IdPost).FirstOrDefault();

            if (appfile == null)
            {
                respuesta.Descripcion = "El archivo no se encontro";
                return Ok(respuesta);
            }
            else
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    appfile.Name = fileName;
                    appfile.FileType = fileExtension;
                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        appfile.DataFiles = target.ToArray();
                    }
                    _context.SaveChanges();
                    respuesta.Descripcion = "El archivo se actualizo correctamente";
                }
            
            }
              return Ok(respuesta); 
        }
    }
}
