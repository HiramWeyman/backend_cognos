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
    public class GeneroController : ControllerBase
    {
        private readonly IGeneroRepositorio _perRepo;
        private readonly IMapper _mapper;

        public GeneroController(IGeneroRepositorio perRepo, IMapper mapper)
        {
            _perRepo = perRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getGenero() 
        {
            var listaGenero=_perRepo.GetGenero();
            var listaGeneroDto = new List<GeneroDto>();
            foreach (var lista in listaGenero) {

                listaGeneroDto.Add(_mapper.Map<GeneroDto>(lista));
            }
            return Ok(listaGeneroDto);
        }

        [HttpGet("{id:int}",Name = "getGenero")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getGenero(int id)
        {
            var itemGenero = _perRepo.GetGenero(id);
           
            if (itemGenero==null) {
                return NotFound();
            }
            var itemGenerosDto = _mapper.Map<GeneroDto>(itemGenero);

            return Ok(itemGenerosDto);
        }

        [HttpPost]
        [ProducesResponseType(201,Type =typeof(GeneroDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearGenero([FromBody]CrearGeneroDto Genero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Genero==null)
            {
                return BadRequest(ModelState);
            }
            if (_perRepo.ExisteGenero(Genero.gen_desc)) 
            {
                ModelState.AddModelError("","Este Genero ya existe");
                return StatusCode(404, ModelState);
            }
            var Generodto = _mapper.Map<Genero>(Genero);
            if (!_perRepo.CrearGenero(Generodto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {Generodto.gen_desc}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getGenero", new { id= Generodto.gen_id}, Generodto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchGenero")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchGenero(int id, [FromBody] GeneroDto GeneroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (GeneroDto== null || GeneroDto.gen_id!=id)
            {
                return BadRequest(ModelState);
            }
         
            var per= _mapper.Map<Genero>(GeneroDto);
            if (!_perRepo.ActualizarGenero(per))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {per.gen_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarGenero")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarGenero(int id)
        {

            if (_perRepo.ExisteGenero(id)) 
            {
                return NotFound();
            }

            var per = _perRepo.GetGenero(id);
            if (!_perRepo.BorrarGenero(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.gen_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
