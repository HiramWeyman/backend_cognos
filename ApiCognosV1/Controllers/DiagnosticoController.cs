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
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoDS_Repositorio _pacRepo;
        private readonly IMapper _mapper;
        public DiagnosticoController(IDiagnosticoDS_Repositorio pacRepo, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;
        }


        [HttpGet("{id:int}", Name = "getDiagnostico")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getDiagnostico(int id)
        {
            var itemDiagnostico = _pacRepo.GetDiagnistico(id);

            if (itemDiagnostico == null)
            {
                return NotFound();
            }
            var itemDiagnosticoDto = _mapper.Map<DiagnosticoDS_Dto>(itemDiagnostico);

            return Ok(itemDiagnosticoDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(DiagnosticoDS_Dto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearDiagnostico([FromBody] CrearDiagnosticoDS_Dto diag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (diag == null)
            {
                return BadRequest(ModelState);
            }
          
            var diagdto = _mapper.Map<DiagnosticoDS>(diag);
            if (!_pacRepo.CrearDiagnostico(diagdto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {diag.diag_desc}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getDiagnostico", new { id = diagdto.diag_id }, diagdto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchDiagnostico")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchDiagnostico(int id, [FromBody] DiagnosticoDS_Dto diagDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (diagDto == null || diagDto.diag_id != id)
            {
                return BadRequest(ModelState);
            }

            var diag = _mapper.Map<DiagnosticoDS>(diagDto);
            if (!_pacRepo.ActualizarDiagnostico(diag))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {diag.diag_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
