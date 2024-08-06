using ApiCognosV1.Data;
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
    public class CreenciasController : ControllerBase
    {
        private readonly ICreenciasRepositorio _pacRepo;
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _context;

        public CreenciasController(ICreenciasRepositorio pacRepo, IMapper mapper, ApplicationDBContext context)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id:int}", Name = "getCreencias")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getCreencias(int id)
        {
            var itemCreencias = _pacRepo.GetCreencias(id);

            if (itemCreencias == null)
            {
                return NotFound();
            }
            var itemCreenciasDto = _mapper.Map<CreenciasDto>(itemCreencias);

            return Ok(itemCreenciasDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CreenciasDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearCreencias([FromBody] CrearCreenciaDto Creencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Creencias == null)
            {
                return BadRequest(ModelState);
            }

            var Creenciasdto = _mapper.Map<Creencias>(Creencias);
            if (!_pacRepo.CrearCreencias(Creenciasdto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {Creencias.creencia_fecha_captura}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getCreencias", new { id = Creenciasdto.creencia_id }, Creenciasdto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchCreencias")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchCreencias(int id, [FromBody] CreenciasDto CreenciasDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (CreenciasDto == null || CreenciasDto.creencia_id != id)
            {
                return BadRequest(ModelState);
            }

            var Creencias = _mapper.Map<Creencias>(CreenciasDto);
            if (!_pacRepo.ActualizarCreencias(Creencias))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {Creencias.creencia_id}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }


        //Cambios nuevos en informe
        [HttpGet]
        [Route("GetIdsPruebaEllis/{Id}")]
        public IEnumerable<mostrar_exp> GetIdsPruebaEllis(int Id)
        {
            return _context.mostrar_exp.Where(e => e.most_expediente == Id && e.most_tipo_prueba == 6).ToList();
        }



    }
}
