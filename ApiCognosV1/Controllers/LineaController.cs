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
    public class LineaController : ControllerBase
    {
        private readonly ILineaVidaRepositorio _perRepo;
        private readonly IMapper _mapper;

        public LineaController(ILineaVidaRepositorio perRepo, IMapper mapper)
        {
            _perRepo = perRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getLineaVidaList(int id)
        {
            var listaLinea = _perRepo.GetLineaVida(id);
            var listaLineaDto = new List<LineaVidaDto>();
            foreach (var lista in listaLinea)
            {

                listaLineaDto.Add(_mapper.Map<LineaVidaDto>(lista));
            }
            return Ok(listaLineaDto);
        }

        [HttpGet("{id:int}", Name = "getLinea")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getLinea(int id)
        {
            var itemLinea = _perRepo.GetLineaVidaUp(id);

            if (itemLinea == null)
            {
                return NotFound();
            }
            var itemLineaVidaDto = _mapper.Map<LineaVidaDto>(itemLinea);

            return Ok(itemLineaVidaDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(LineaVidaDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearLineaVida([FromBody] CrearLineaVidaDto tr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (tr == null)
            {
                return BadRequest(ModelState);
            }
          
            var lineadto = _mapper.Map<LineaVida>(tr);
            if (!_perRepo.CrearLineaVida(lineadto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {lineadto.lin_desc}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getLinea", new { id = lineadto.lin_id }, lineadto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarLineaVida")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarLineaVida(int id, [FromBody] LineaVidaDto lineaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (lineaDto == null || lineaDto.lin_id != id)
            {
                return BadRequest(ModelState);
            }

            var tr = _mapper.Map<LineaVida>(lineaDto);
            if (!_perRepo.ActualizarLineaVida(tr))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {tr.lin_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarLineaVida")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarLineaVida(int id)
        {

            var per = _perRepo.GetLineaVidaUp(id);
            if (!_perRepo.BorrarLineaVida(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.lin_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
