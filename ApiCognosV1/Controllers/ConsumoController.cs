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
    public class ConsumoController : ControllerBase
    {
        private readonly IConsumoSust_Repositorio _perRepo;
        private readonly IMapper _mapper;

        public ConsumoController(IConsumoSust_Repositorio perRepo, IMapper mapper)
        {
            _perRepo = perRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getConsumoList(int id)
        {
            var listaConsumo = _perRepo.GetConsumoSust(id);
            var listaConsumoDto = new List<ConsumoSustDto>();
            foreach (var lista in listaConsumo)
            {

                listaConsumoDto.Add(_mapper.Map<ConsumoSustDto>(lista));
            }
            return Ok(listaConsumoDto);
        }

        [HttpGet("{id:int}", Name = "getConsumo")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getConsumo(int id)
        {
            var itemConsumo = _perRepo.GetConsumoSustUp(id);

            if (itemConsumo == null)
            {
                return NotFound();
            }
            var itemConsumoDto = _mapper.Map<ConsumoSustDto>(itemConsumo);

            return Ok(itemConsumoDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ConsumoSustDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearConsumo([FromBody] CrearConsumoSustDto prob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (prob == null)
            {
                return BadRequest(ModelState);
            }
          
            var Consumodto = _mapper.Map<ConsumoSust>(prob);
            if (!_perRepo.CrearConsumo(Consumodto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {Consumodto.consumo_sustancia}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getConsumo", new { id = Consumodto.consumo_id }, Consumodto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchConsumo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchConsumo(int id, [FromBody] ConsumoSustDto probDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (probDto == null || probDto.consumo_id != id)
            {
                return BadRequest(ModelState);
            }

            var prob = _mapper.Map<ConsumoSust>(probDto);
            if (!_perRepo.ActualizarConsumo(prob))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {prob.consumo_sustancia}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarConsumo")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarProblema(int id)
        {

            var per = _perRepo.GetConsumoSustUp(id);
            if (!_perRepo.BorrarConsumo(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.consumo_sustancia}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
