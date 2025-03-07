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
    public class ReasignarPacController : ControllerBase
    {
        //private readonly ICreenciasRepositorio _pacRepo;
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public ReasignarPacController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;
            _mapper = mapper;
        }

        [HttpPatch]
        [Route("Reasignarpac")]
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
                _context.Pacientes.Update(paciente);
                _context.SaveChanges();
                respuesta.Descripcion = "El paciente se actualizo correctamente";

            }
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("getUsuariosTera")]
        public IEnumerable<Usuarios> GetUsuarios()
        {

            return _context.Usuarios.Where(p => p.usr_estatus == "A" && p.usr_per_id !=1).OrderBy(p=>p.usr_paterno).ToList();
        }
    }
}
