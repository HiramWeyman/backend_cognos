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
    public class FormCasoController : ControllerBase
    {
        private readonly IFormCasoRepositorio _pacRepo;
        private readonly IMapper _mapper;

        public FormCasoController(IFormCasoRepositorio pacRepo, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;
        }

        [HttpGet("{id:int}", Name = "getFormCaso")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getFormCaso(int id)
        {
            var itemForm = _pacRepo.GetFormCaso(id);

            if (itemForm == null)
            {
                return NotFound();
            }
            var itemFormDto = _mapper.Map<FormCasoDto>(itemForm);

            return Ok(itemFormDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(FormCasoDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearOtras([FromBody] CrearFormCasoDto frm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (frm == null)
            {
                return BadRequest(ModelState);
            }

            var frmdto = _mapper.Map<FormCaso>(frm);
            if (!_pacRepo.CrearFormCaso(frmdto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {frm.form_hipotesis}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getFormCaso", new { id = frmdto.form_id }, frmdto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchFormCaso")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchFormCaso(int id, [FromBody] FormCasoDto frmDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (frmDto == null || frmDto.form_id != id)
            {
                return BadRequest(ModelState);
            }

            var frm = _mapper.Map<FormCaso>(frmDto);
            if (!_pacRepo.ActualizarFormCaso(frm))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {frm.form_hipotesis}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
