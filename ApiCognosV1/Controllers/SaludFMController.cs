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
    public class SaludFMController : ControllerBase
    {
        private readonly ISaludFM_Repositorio _pacRepo;
        private readonly IMapper _mapper;

        public SaludFMController(ISaludFM_Repositorio pacRepo, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;
        }



        [HttpGet("{id:int}",Name = "getSaludFM")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getSaludFM(int id)
        {
            var itemSaludFM = _pacRepo.GetSalud(id);
           
            if (itemSaludFM == null) {
                return NotFound();
            }
            var itemSaludDto = _mapper.Map<SaludFM_Dto>(itemSaludFM);

            return Ok(itemSaludDto);
        }

        [HttpPost]
        [ProducesResponseType(201,Type =typeof(PacientesDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearSaludFM([FromBody]CrearSaludFM_Dto salud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (salud == null)
            {
                return BadRequest(ModelState);
            }
            //if (_perRepo.ExistePerfil(perfil.per_desc)) 
            //{
            //    ModelState.AddModelError("","Este perfil ya existe");
            //    return StatusCode(404, ModelState);
            //}
            var saluddto = _mapper.Map<SaludFM>(salud);
            if (!_pacRepo.CrearSalud(saluddto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {saluddto.salud_sueno}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getSaludFM", new { id= saluddto.salud_id}, saluddto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchSalud")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchSalud(int id, [FromBody] SaludFM_Dto saludDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (saludDto == null || saludDto.salud_id!=id)
            {
                return BadRequest(ModelState);
            }
         
            var salud= _mapper.Map<SaludFM>(saludDto);
            if (!_pacRepo.ActualizarSalud(salud))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {salud.salud_sueno}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }


    }
}
