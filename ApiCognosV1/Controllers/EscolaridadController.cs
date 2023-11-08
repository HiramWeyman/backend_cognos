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
    public class EscolaridadController : ControllerBase
    {
        private readonly IEscolaridadRepositorio _perRepo;
        private readonly IMapper _mapper;

        public EscolaridadController(IEscolaridadRepositorio perRepo, IMapper mapper)
        {
            _perRepo = perRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getEscolaridad() 
        {
            var listaEscolaridad=_perRepo.GetEscolaridad();
            var listaEscolaridadDto = new List<EscolaridadDto>();
            foreach (var lista in listaEscolaridad) {

                listaEscolaridadDto.Add(_mapper.Map<EscolaridadDto>(lista));
            }
            return Ok(listaEscolaridadDto);
        }

        [HttpGet("{id:int}",Name = "getEscolaridad")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getEscolaridad(int id)
        {
            var itemEscolaridad = _perRepo.GetEscolaridad(id);
           
            if (itemEscolaridad==null) {
                return NotFound();
            }
            var itemEscolaridadsDto = _mapper.Map<EscolaridadDto>(itemEscolaridad);

            return Ok(itemEscolaridadsDto);
        }

        [HttpPost]
        [ProducesResponseType(201,Type =typeof(EscolaridadDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearEscolaridad([FromBody]CrearEscolaridadDto Escolaridad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Escolaridad==null)
            {
                return BadRequest(ModelState);
            }
            if (_perRepo.ExisteEscolaridad(Escolaridad.esc_desc)) 
            {
                ModelState.AddModelError("","Este Escolaridad ya existe");
                return StatusCode(404, ModelState);
            }
            var Escolaridaddto = _mapper.Map<Escolaridad>(Escolaridad);
            if (!_perRepo.CrearEscolaridad(Escolaridaddto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {Escolaridaddto.esc_desc}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getEscolaridad", new { id= Escolaridaddto.esc_id}, Escolaridaddto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchEscolaridad")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchEscolaridad(int id, [FromBody] EscolaridadDto EscolaridadDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (EscolaridadDto== null || EscolaridadDto.esc_id!=id)
            {
                return BadRequest(ModelState);
            }
         
            var per= _mapper.Map<Escolaridad>(EscolaridadDto);
            if (!_perRepo.ActualizarEscolaridad(per))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {per.esc_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarEscolaridad")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarEscolaridad(int id)
        {

            if (_perRepo.ExisteEscolaridad(id)) 
            {
                return NotFound();
            }

            var per = _perRepo.GetEscolaridad(id);
            if (!_perRepo.BorrarEscolaridad(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.esc_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
