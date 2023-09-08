using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvolucionController : ControllerBase
    {
        private readonly IEvolucionPR_Repositorio _pacRepo;
        private readonly IMapper _mapper;

        public EvolucionController(IEvolucionPR_Repositorio pacRepo, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;
        }

        [HttpGet("{id:int}", Name = "getEvolucion")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getEvolucion(int id)
        {
            var itemEvo = _pacRepo.GetEvolucion(id);

            if (itemEvo == null)
            {
                return NotFound();
            }
            var itemEvoDto = _mapper.Map<EvolucionPR_Dto>(itemEvo);

            return Ok(itemEvoDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(EvolucionPR_Dto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearOtras([FromBody] CrearEvolucionPR_Dto evo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (evo == null)
            {
                return BadRequest(ModelState);
            }

            var evodto = _mapper.Map<EvolucionPR>(evo);
            if (!_pacRepo.CrearEvolucion(evodto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {evo.evo_desc}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getEvolucion", new { id = evodto.evo_id }, evodto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchEvolucion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchEvolucion(int id, [FromBody] EvolucionPR_Dto evoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (evoDto == null || evoDto.evo_id != id)
            {
                return BadRequest(ModelState);
            }

            var evo = _mapper.Map<EvolucionPR>(evoDto);
            if (!_pacRepo.ActualizarEvolucion(evo))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {evo.evo_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
