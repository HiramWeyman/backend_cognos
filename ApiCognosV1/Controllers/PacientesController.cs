using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacientesRepositorio _pacRepo;
        private readonly IMapper _mapper;

        public PacientesController(IPacientesRepositorio pacRepo, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;
        }

        [HttpGet( Name = "getPacientes")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getPacientes() 
        {
            var listaPacientes= _pacRepo.GetPacientes();
            var listaPacientesDto = new List<PacientesDto>();
            foreach (var lista in listaPacientes) {

                listaPacientesDto.Add(_mapper.Map<PacientesDto>(lista));
            }
            return Ok(listaPacientesDto);
        }

        [HttpGet("{id:int}",Name = "getPaciente")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getPaciente(int id)
        {
            var itemPaciente = _pacRepo.GetPacientes(id);
           
            if (itemPaciente == null) {
                return NotFound();
            }
            var itemPacienteDto = _mapper.Map<PacientesDto>(itemPaciente);

            return Ok(itemPacienteDto);
        }

        [HttpPost]
        [ProducesResponseType(201,Type =typeof(PacientesDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearPerfil([FromBody]CrearPacientesDto paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (paciente == null)
            {
                return BadRequest(ModelState);
            }
            //if (_perRepo.ExistePerfil(perfil.per_desc)) 
            //{
            //    ModelState.AddModelError("","Este perfil ya existe");
            //    return StatusCode(404, ModelState);
            //}
            var pacientedto = _mapper.Map<Pacientes>(paciente);
            if (!_pacRepo.CrearPaciente(pacientedto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {pacientedto.pac_nombre}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getPerfil", new { id= pacientedto.pac_id}, pacientedto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchPaciente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchPerfil(int id, [FromBody] PacientesDto pacienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (pacienteDto == null || pacienteDto.pac_id!=id)
            {
                return BadRequest(ModelState);
            }
         
            var pac= _mapper.Map<Pacientes>(pacienteDto);
            if (!_pacRepo.ActualizarPaciente(pac))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {pac.pac_nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        //[HttpDelete("{id:int}", Name = "BorrarPerfil")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult BorrarPerfil(int id)
        //{

        //    if (_perRepo.ExistePerfil(id)) 
        //    {
        //        return NotFound();
        //    }

        //    var per = _perRepo.GetPerfiles(id);
        //    if (!_perRepo.BorrarPerfil(per))
        //    {
        //        ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.per_desc}");
        //        return StatusCode(500, ModelState);
        //    }
        //    return NoContent();

        //}
    }
}
