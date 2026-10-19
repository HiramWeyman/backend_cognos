using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XAct;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiCognosV1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ArchivarPacController : ControllerBase
    {
        //private readonly ICreenciasRepositorio _pacRepo;
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public ArchivarPacController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;
            _mapper = mapper;
        }

        [HttpPatch]
        [Route("reactivarPac")]
        public IActionResult PacienteUpdate([FromBody] PacienteUpdateDto1 request)
        {
            var respuesta = new Respuesta();

            var paciente = _context.Pacientes.Where(x => x.pac_id == request.Id).FirstOrDefault();

            if (paciente == null)
            {
                respuesta.Descripcion = "El paciente no se encontro";
                return Ok(respuesta);
            }
            else
            {
                // Solo asignar autor si viene un ID válido (> 0)
                if (request.Autor > 0)
                {
                    paciente.pac_usr_id = request.Autor;
                }

                // Solo asignar colaborador si viene un ID válido (> 0)
                if (request.Colaborador > 0)
                {
                    paciente.pac_comparte_usrid = request.Colaborador;
                }

                paciente.eliminado = false;
                _context.Pacientes.Update(paciente);
                _context.SaveChanges();
                respuesta.Descripcion = "El paciente se reactivo correctamente";
            }
            return Ok(respuesta);
        }


        /*    [HttpPatch]
           [Route("reactivarPac")]
           public IActionResult PacienteUpdate([FromBody] PacienteUpdateDto1 request)
           {
               var respuesta = new Respuesta();

               var paciente = _context.Pacientes.Where(x => x.pac_id == request.Id).FirstOrDefault();

               if (paciente == null)
               {
                   respuesta.Descripcion = "El paciente no se encontro";
                   return Ok(respuesta);
               }
               else
               {
                   paciente.pac_usr_id = request.Autor;
                   paciente.pac_comparte_usrid = request.Colaborador;
                   paciente.eliminado = false;
                   _context.Pacientes.Update(paciente);
                   _context.SaveChanges();
                   respuesta.Descripcion = "El paciente se reactivo correctamente";

               }
               return Ok(respuesta);
           }
    */
        [HttpGet("ObtenerPacientesDesactivados")]
        public IActionResult ObtenerPacientesDesactivados()
        {
            var pacientes = _context.Pacientes
                .Where(p => p.eliminado == true)
                .ToList();

            return Ok(pacientes);
        }

        [HttpGet]
        [Route("getUsuariosArchivar")]
        public IEnumerable<Usuarios> GetUsuarios()
        {

            return _context.Usuarios.Where(p => p.usr_estatus == "A" && p.usr_per_id != 1).OrderBy(p => p.usr_paterno).ToList();
        }

        [HttpPatch("DesactivarPaciente/{id}")]
        public IActionResult DesactivarPaciente(int id)
        {
            var paciente = _context.Pacientes
                .FirstOrDefault(p => p.pac_id == id);

            if (paciente == null)
            {
                return NotFound(new
                {
                    mensaje = "El paciente no existe."
                });
            }

            if (paciente.eliminado == true)
            {
                return BadRequest(new
                {
                    mensaje = "El paciente ya está desactivado."
                });
            }

            paciente.eliminado = true;
            _context.Pacientes.Update(paciente);

            _context.SaveChanges();

            return Ok(new
            {
                mensaje = "Paciente desactivado correctamente.",
                paciente = paciente.pac_id
            });
        }
    }
}
