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
    public class ProbobjController : ControllerBase
    {
        private readonly IProbObjRepositorio _perRepo;
        private readonly IMapper _mapper;

        public ProbobjController(IProbObjRepositorio perRepo, IMapper mapper)
        {
            _perRepo = perRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getTratamientoList(int id)
        {
            var listaProb = _perRepo.GetProbObj(id);
            var listaProbDto = new List<ProObjDto>();
            foreach (var lista in listaProb)
            {

                listaProbDto.Add(_mapper.Map<ProObjDto>(lista));
            }
            return Ok(listaProbDto);
        }

        [HttpGet("{id:int}", Name = "getProbObj")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getProbObj(int id)
        {
            var itemProb = _perRepo.GetProbObjUp(id);

            if (itemProb == null)
            {
                return NotFound();
            }
            var itemProObjDto = _mapper.Map<ProObjDto>(itemProb);

            return Ok(itemProObjDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProObjDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearProbObj([FromBody] CrearProObjDto tr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (tr == null)
            {
                return BadRequest(ModelState);
            }

            var probdto = _mapper.Map<ProbObj>(tr);
            if (!_perRepo.CrearProbObj(probdto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {probdto.pro_problema}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getProbObj", new { id = probdto.pro_id }, probdto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarProbObj")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarProbObj(int id, [FromBody] ProObjDto probDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (probDto == null || probDto.pro_id != id)
            {
                return BadRequest(ModelState);
            }

            var tr = _mapper.Map<ProbObj>(probDto);
            if (!_perRepo.ActualizarProbObj(tr))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {tr.pro_problema}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarProObj")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarProObj(int id)
        {

            var per = _perRepo.GetProbObjUp(id);
            if (!_perRepo.BorrarProbObj(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.pro_problema}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
