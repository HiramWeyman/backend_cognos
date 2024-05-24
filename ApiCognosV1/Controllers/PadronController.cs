using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCognosV1.Controllers
{
 
    public class PadronController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PadronController( ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/padronUsuarios")]
        public IActionResult padronUsuarios()
        {
            //var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (1, 11, 21, 31, 41, 51, 61, 71, 81, 91) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            List<Padron_Cognos> users = _context.Padron_Cognos.OrderBy(x=>x.pad_nombre).ToList();
            return Ok(users);
        }


        [HttpGet]
        [Route("api/validaPadUsr/{mail}")]
        public IActionResult validaUsr(string mail)
        {
            //var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (1, 11, 21, 31, 41, 51, 61, 71, 81, 91) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            int valorRes = _context.Padron_Cognos.Where(p => p.pad_correo.ToLower() == mail.Trim().ToLower()).Count();
            return Ok(valorRes);
        }

        [HttpPost]
        [Route("api/insertaPadron")]
        public IActionResult insertaPadron([FromBody] Padron_Cognos resp)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            var respuesta = new Respuesta();

            if (resp != null)
            {
                Console.WriteLine(resp);
                var objfiles = new Padron_Cognos()
                {
                    pad_id = 0,
                    //Name = newFileName,
                    pad_nombre = resp.pad_nombre,
                    pad_correo = resp.pad_correo,
                    pad_fecha_creacion= DateTime.Now,
                    pad_estatus= resp.pad_estatus

                };

                _context.Padron_Cognos.Add(objfiles);
                _context.SaveChanges();
                respuesta.Descripcion = "Usuario registrado correctamente";
            }

            return Ok(respuesta);
        }


        [HttpPatch]
        [Route("api/updatePadEstatus/{Id}")]
        public IActionResult updatePadEstatus(int Id)
        {
            var respuesta = new Respuesta();
            Padron_Cognos resp = new Padron_Cognos();
            Usuarios respUsr = new Usuarios();
            //get the data from the different tables with the id sending from the MVC controller
            resp = _context.Padron_Cognos.Where(x => x.pad_id == Id).FirstOrDefault();

            if (resp == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                if (resp.pad_estatus == "A")
                {
                    resp.pad_estatus = "I";
                    _context.Padron_Cognos.Update(resp);
                    _context.SaveChanges();

                    ///Desactivar el usuario de login
                    respUsr = _context.Usuarios.Where(x => x.usr_email.Trim().ToLower() == resp.pad_correo.Trim().ToLower()).FirstOrDefault();
                    if (respUsr!=null) {
                        respUsr.usr_estatus = "I";
                        _context.Usuarios.Update(respUsr);
                        _context.SaveChanges();
                    }

                    respuesta.Descripcion = "Usuario Desactivado Correctamente";


                }
                else {
                    resp.pad_estatus = "A";
                    _context.Padron_Cognos.Update(resp);
                    _context.SaveChanges();
                    ///Activar el usuario de login
                    respUsr = _context.Usuarios.Where(x => x.usr_email.Trim().ToLower() == resp.pad_correo.Trim().ToLower()).FirstOrDefault();
                    if (respUsr != null)
                    {
                        respUsr.usr_estatus = "A";
                        _context.Usuarios.Update(respUsr);
                        _context.SaveChanges();
                    }
                    respuesta.Descripcion = "Usuario Activado Correctamente";

                }
              
            }
            return Ok(respuesta);
        }
    }
}
