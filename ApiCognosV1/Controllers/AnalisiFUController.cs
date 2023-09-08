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
    public class AnalisisFUController : ControllerBase
    {
        private readonly IAnalisisFU_Repositorio _pacRepo;
        private readonly IMapper _mapper;

        public AnalisisFUController(IAnalisisFU_Repositorio pacRepo, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;
        }



        [HttpGet("{id:int}",Name = "getAnalisisFU")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getAnalisisFU(int id)
        {
            var itemAnalisisFU = _pacRepo.GetAnalisis(id);
           
            if (itemAnalisisFU == null) {
                return NotFound();
            }
            var itemAnalisisDto = _mapper.Map<AnalisisFU_Dto>(itemAnalisisFU);

            return Ok(itemAnalisisDto);
        }

        [HttpPost]
        [ProducesResponseType(201,Type =typeof(AnalisisFU_Dto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearAnalisisFU([FromBody]CrearAnalisisFU_Dto analisis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (analisis == null)
            {
                return BadRequest(ModelState);
            }
            //if (_perRepo.ExistePerfil(perfil.per_desc)) 
            //{
            //    ModelState.AddModelError("","Este perfil ya existe");
            //    return StatusCode(404, ModelState);
            //}
            var analisisdto = _mapper.Map<AnalisisFU>(analisis);
            if (!_pacRepo.CrearAnalisis(analisisdto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {analisisdto.analisis_ant}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getAnalisisFU", new { id= analisisdto.analisis_id}, analisisdto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchAnalisis")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchAnalisis(int id, [FromBody] AnalisisFU_Dto analisisDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (analisisDto == null || analisisDto.analisis_id!=id)
            {
                return BadRequest(ModelState);
            }
         
            var analisis= _mapper.Map<AnalisisFU>(analisisDto);
            if (!_pacRepo.ActualizarAnalisis(analisis))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {analisis.analisis_ant}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }


    }
}
