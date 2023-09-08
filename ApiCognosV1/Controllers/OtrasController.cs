using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtrasController : ControllerBase
    {
        private readonly IOtrasAR_Repositorio _pacRepo;
        private readonly IMapper _mapper;

        public OtrasController(IOtrasAR_Repositorio pacRepo, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;
        }

        [HttpGet("{id:int}", Name = "getOtras")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getOtras(int id)
        {
            var itemOtras = _pacRepo.GetOtras(id);

            if (itemOtras == null)
            {
                return NotFound();
            }
            var itemOtrasDto = _mapper.Map<OtrasAR_Dto>(itemOtras);

            return Ok(itemOtrasDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(DiagnosticoDS_Dto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearOtras([FromBody] CrearOtrasAR_Dto otras)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (otras == null)
            {
                return BadRequest(ModelState);
            }

            var otrasdto = _mapper.Map<OtrasAR>(otras);
            if (!_pacRepo.CrearOtras(otrasdto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {otras.otras_desc}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getOtras", new { id = otrasdto.otras_id }, otrasdto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchOtras")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchOtras(int id, [FromBody] OtrasAR_Dto otrasDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (otrasDto == null || otrasDto.otras_id != id)
            {
                return BadRequest(ModelState);
            }

            var otras = _mapper.Map<OtrasAR>(otrasDto);
            if (!_pacRepo.ActualizarOtras(otras))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {otras.otras_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

    }
}
