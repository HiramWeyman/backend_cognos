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
    public class PerfilesController : ControllerBase
    {
        private readonly IPerfilesRepositorio _perRepo;
        private readonly IMapper _mapper;

        public PerfilesController(IPerfilesRepositorio perRepo, IMapper mapper)
        {
            _perRepo = perRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getPerfiles() 
        {
            var listaPerfiles=_perRepo.GetPerfiles();
            var listaPerfilesDto = new List<PerfilesDto>();
            foreach (var lista in listaPerfiles) {

                listaPerfilesDto.Add(_mapper.Map<PerfilesDto>(lista));
            }
            return Ok(listaPerfilesDto);
        }

        [HttpGet("{id:int}",Name = "getPerfil")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getPerfil(int id)
        {
            var itemPerfil = _perRepo.GetPerfiles(id);
           
            if (itemPerfil==null) {
                return NotFound();
            }
            var itemPerfilsDto = _mapper.Map<PerfilesDto>(itemPerfil);

            return Ok(itemPerfilsDto);
        }

        [HttpPost]
        [ProducesResponseType(201,Type =typeof(PerfilesDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearPerfil([FromBody]CrearPerfilesDto perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (perfil==null)
            {
                return BadRequest(ModelState);
            }
            if (_perRepo.ExistePerfil(perfil.per_desc)) 
            {
                ModelState.AddModelError("","Este perfil ya existe");
                return StatusCode(404, ModelState);
            }
            var perfildto = _mapper.Map<Perfiles>(perfil);
            if (!_perRepo.CrearPerfil(perfildto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {perfildto.per_desc}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getPerfil", new { id= perfildto.per_id}, perfildto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchPerfil")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchPerfil(int id, [FromBody] PerfilesDto perfilDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (perfilDto== null || perfilDto.per_id!=id)
            {
                return BadRequest(ModelState);
            }
         
            var per= _mapper.Map<Perfiles>(perfilDto);
            if (!_perRepo.ActualizarPerfil(per))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {per.per_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarPerfil")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarPerfil(int id)
        {

            if (_perRepo.ExistePerfil(id)) 
            {
                return NotFound();
            }

            var per = _perRepo.GetPerfiles(id);
            if (!_perRepo.BorrarPerfil(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.per_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
