using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaMController : ControllerBase
    {
        private readonly IConsultaMRepositorio _pacRepo;
        private readonly IMapper _mapper;

        public ConsultaMController(IConsultaMRepositorio pacRepo, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;
        }

        [HttpGet("{id:int}", Name = "getConsulta")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getConsulta(int id)
        {
            var itemCons = _pacRepo.GetConsulta(id);

            if (itemCons == null)
            {
                return NotFound();
            }
            var itemConsDto = _mapper.Map<ConsultaDto>(itemCons);

            return Ok(itemConsDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ConsultaDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearConsulta([FromBody] CrearConsultaDto cons)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (cons == null)
            {
                return BadRequest(ModelState);
            }

            var consdto = _mapper.Map<ConsultaM>(cons);
            if (!_pacRepo.CrearConsulta(consdto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {cons.con_motivo}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getConsulta", new { id = consdto.con_id }, consdto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchConsulta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchConsulta(int id, [FromBody] ConsultaDto conDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (conDto == null || conDto.con_id != id)
            {
                return BadRequest(ModelState);
            }

            var con = _mapper.Map<ConsultaM>(conDto);
            if (!_pacRepo.ActualizarConsulta(con))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {con.con_motivo}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
