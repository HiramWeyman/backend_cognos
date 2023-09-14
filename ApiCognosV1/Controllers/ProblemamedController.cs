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
    public class ProblemamedController : ControllerBase
    {
        private readonly IProblemasMed_Repositorio _perRepo;
        private readonly IMapper _mapper;

        public ProblemamedController(IProblemasMed_Repositorio perRepo, IMapper mapper)
        {
            _perRepo = perRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getProblemasList(int id)
        {
            var listaProblemas = _perRepo.GetProblemasMed(id);
            var listaProblemasDto = new List<ProblemasMedDto>();
            foreach (var lista in listaProblemas)
            {

                listaProblemasDto.Add(_mapper.Map<ProblemasMedDto>(lista));
            }
            return Ok(listaProblemasDto);
        }

        [HttpGet("{id:int}", Name = "getProblema")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getProblema(int id)
        {
            var itemProblema = _perRepo.GetProblemasMedUp(id);

            if (itemProblema == null)
            {
                return NotFound();
            }
            var itemProblemaDto = _mapper.Map<ProblemasMedDto>(itemProblema);

            return Ok(itemProblemaDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProblemasMedDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearPoblema([FromBody] CrearProblemasMedDto prob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (prob == null)
            {
                return BadRequest(ModelState);
            }
          
            var problemadto = _mapper.Map<ProblemasMed>(prob);
            if (!_perRepo.CrearProblema(problemadto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {problemadto.problema_problema}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getProblema", new { id = problemadto.problema_id }, problemadto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchProblema")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchProblema(int id, [FromBody] ProblemasMedDto probDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (probDto == null || probDto.problema_id != id)
            {
                return BadRequest(ModelState);
            }

            var prob = _mapper.Map<ProblemasMed>(probDto);
            if (!_perRepo.ActualizarProblemas(prob))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {prob.problema_problema}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarProblema")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarProblema(int id)
        {

            var per = _perRepo.GetProblemasMedUp(id);
            if (!_perRepo.BorrarProblema(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.problema_problema}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
