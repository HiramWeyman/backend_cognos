using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientoController : ControllerBase
    {
        private readonly ITratamientoRepositorio _perRepo;
        private readonly IMapper _mapper;

        public TratamientoController(ITratamientoRepositorio perRepo, IMapper mapper)
        {
            _perRepo = perRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getTratamientoList(int id)
        {
            var listaTratamiento = _perRepo.GetTratamiento(id);
            var listaTratamientoDto = new List<TratamientoDto>();
            foreach (var lista in listaTratamiento)
            {

                listaTratamientoDto.Add(_mapper.Map<TratamientoDto>(lista));
            }
            return Ok(listaTratamientoDto);
        }

        [HttpGet("{id:int}", Name = "getTratamiento")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getPrevio(int id)
        {
            var itemTratamiento = _perRepo.GetTratamientoUp(id);

            if (itemTratamiento == null)
            {
                return NotFound();
            }
            var itemTratamientoDto = _mapper.Map<TratamientoDto>(itemTratamiento);

            return Ok(itemTratamientoDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(TratamientoDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearTratamiento([FromBody] CrearTratamientoDto tr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (tr == null)
            {
                return BadRequest(ModelState);
            }
          
            var tratadto = _mapper.Map<Tratamiento>(tr);
            if (!_perRepo.CrearTratamiento(tratadto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {tratadto.trata_objetivo}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getTratamiento", new { id = tratadto.trata_id }, tratadto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarTratamiento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarTratamiento(int id, [FromBody] TratamientoDto trataDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (trataDto == null || trataDto.trata_id != id)
            {
                return BadRequest(ModelState);
            }

            var tr = _mapper.Map<Tratamiento>(trataDto);
            if (!_perRepo.ActualizarTratamiento(tr))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {tr.trata_objetivo}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarTratamiento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarTratamiento(int id)
        {

            var per = _perRepo.GetTratamientoUp(id);
            if (!_perRepo.BorrarTratamiento(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.trata_objetivo}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
