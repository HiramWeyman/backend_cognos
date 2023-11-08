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
    public class TerapeutaController : ControllerBase
    {
        private readonly ITerapeutasRepositorio _pacRepo;
        private readonly IMapper _mapper;

        public TerapeutaController(ITerapeutasRepositorio pacRepo, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;
        }

        [HttpGet(Name = "getTerapeutas")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getTerapeutas()
        {
            var listaTerapeutas = _pacRepo.GetTerapeutas();
            var listaTerapeutasDto = new List<cat_terapeutasDto>();
            foreach (var lista in listaTerapeutas)
            {

                listaTerapeutasDto.Add(_mapper.Map<cat_terapeutasDto>(lista));
            }
            return Ok(listaTerapeutasDto);
        }


        [HttpGet("{id:int}", Name = "getTerapeuta")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getTerapeuta(int id)
        {
            var itemTerapeuta = _pacRepo.GetTerapeuta(id);

            if (itemTerapeuta == null)
            {
                return NotFound();
            }
            var itemTerapeutaDto = _mapper.Map<cat_terapeutasDto>(itemTerapeuta);

            return Ok(itemTerapeutaDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(cat_terapeutasDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearTerapeuta([FromBody] CrearCat_terapeutasDto terapeuta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (terapeuta == null)
            {
                return BadRequest(ModelState);
            }
            //if (_perRepo.ExistePerfil(perfil.per_desc)) 
            //{
            //    ModelState.AddModelError("","Este perfil ya existe");
            //    return StatusCode(404, ModelState);
            //}
            var terapeutadto = _mapper.Map<cat_terapeutas>(terapeuta);
            if (!_pacRepo.CrearTerapeuta(terapeutadto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {terapeutadto.tera_paterno}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getTerapeuta", new { id = terapeutadto.tera_id }, terapeutadto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchTerapeuta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchTerapeuta(int id, [FromBody] cat_terapeutasDto terapeutaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (terapeutaDto == null || terapeutaDto.tera_id != id)
            {
                return BadRequest(ModelState);
            }

            var pac = _mapper.Map<cat_terapeutas>(terapeutaDto);
            if (!_pacRepo.ActualizarTerapeuta(pac))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {pac.tera_paterno}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarTerapeuta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarTeraputa(int id)
        {

            //if (_pacRepo.ExistePerfil(id))
            //{
            //    return NotFound();
            //}

            var per = _pacRepo.GetTerapeuta(id);
            if (!_pacRepo.BorrarTerapeuta(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.tera_paterno}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
