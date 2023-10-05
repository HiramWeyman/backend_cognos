using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XAct;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private readonly ISesionRepositorio _perRepo;
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _bd;

        public SesionController(ISesionRepositorio perRepo, IMapper mapper, ApplicationDBContext bd)
        {
            _perRepo = perRepo;
            _mapper = mapper;
            _bd = bd;
        }

       

 

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getSesionList(int id)
        {
            var listaSesion = _perRepo.GetSesion(id);
            var listaSesionDto = new List<SesionDto>();
            foreach (var lista in listaSesion)
            {

                listaSesionDto.Add(_mapper.Map<SesionDto>(lista));
            }
            return Ok(listaSesionDto);
        }

        [HttpGet("{id:int}", Name = "getSesion")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getSesion(int id)
        {
            var itemSesion = _perRepo.GetSesionUp(id);

            if (itemSesion == null)
            {
                return NotFound();
            }
            var itemSesionDto = _mapper.Map<SesionDto>(itemSesion);

            return Ok(itemSesionDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(SesionDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearSesion([FromBody] CrearSesionDto tr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (tr == null)
            {
                return BadRequest(ModelState);
            }

            var sesiondto = _mapper.Map<Sesion>(tr);
            if (!_perRepo.CrearSesion(sesiondto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {sesiondto.sesion_caso}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getSesion", new { id = sesiondto.sesion_id }, sesiondto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarSesion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarSesion(int id, [FromBody] SesionDto sesionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (sesionDto == null || sesionDto.sesion_id != id)
            {
                return BadRequest(ModelState);
            }

            var tr = _mapper.Map<Sesion>(sesionDto);
            if (!_perRepo.ActualizarSesion(tr))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {tr.sesion_caso}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarSesion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarSesion(int id)
        {

            var per = _perRepo.GetSesionUp(id);
            if (!_perRepo.BorrarSesion(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.sesion_caso}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }


     
    }
}
