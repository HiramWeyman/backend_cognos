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
    public class PrevioController : ControllerBase
    {
        private readonly IPrevioSalud_Repositorio _perRepo;
        private readonly IMapper _mapper;

        public PrevioController(IPrevioSalud_Repositorio perRepo, IMapper mapper)
        {
            _perRepo = perRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getPrevioList(int id)
        {
            var listaPrevio = _perRepo.GetPrevioSalud(id);
            var listaPrevioDto = new List<PrevioSaludDto>();
            foreach (var lista in listaPrevio)
            {

                listaPrevioDto.Add(_mapper.Map<PrevioSaludDto>(lista));
            }
            return Ok(listaPrevioDto);
        }

        [HttpGet("{id:int}", Name = "getPrevio")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getPrevio(int id)
        {
            var itemPrevio = _perRepo.GetPrevioSaludUp(id);

            if (itemPrevio == null)
            {
                return NotFound();
            }
            var itemPrevioDto = _mapper.Map<PrevioSaludDto>(itemPrevio);

            return Ok(itemPrevioDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(PrevioSaludDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearPoblema([FromBody] CrearPrevioSaludDto prev)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (prev == null)
            {
                return BadRequest(ModelState);
            }
          
            var prevdto = _mapper.Map<PrevioSalud>(prev);
            if (!_perRepo.CrearPrevio(prevdto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {prevdto.previo_problema}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getPrevio", new { id = prevdto.previo_id }, prevdto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchPrevio")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchProblema(int id, [FromBody] PrevioSaludDto probDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (probDto == null || probDto.previo_id != id)
            {
                return BadRequest(ModelState);
            }

            var prob = _mapper.Map<PrevioSalud>(probDto);
            if (!_perRepo.ActualizarPrevio(prob))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {prob.previo_problema}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarPrevio")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarProblema(int id)
        {

            var per = _perRepo.GetPrevioSaludUp(id);
            if (!_perRepo.BorrarPrevio(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.previo_problema}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
