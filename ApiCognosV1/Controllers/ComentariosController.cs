using ApiCognosV1.Data;
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
    public class ComentariosController : ControllerBase
    {
        private readonly IComentariosRepositorio _perRepo;
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _bd;

        public ComentariosController(IComentariosRepositorio perRepo, IMapper mapper, ApplicationDBContext bd)
        {
            _perRepo = perRepo;
            _mapper = mapper;
            _bd = bd;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getComentariosList(int idx,int id_paciente)
        {
            var listaComentarios = _perRepo.GetComentarios(idx, id_paciente);
            var listaComentariosDto = new List<ComentariosDto>();
            foreach (var lista in listaComentarios)
            {

                listaComentariosDto.Add(_mapper.Map<ComentariosDto>(lista));
            }
            return Ok(listaComentariosDto);
        }

        [HttpGet("{id:int}", Name = "getComentarios")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getComentarios(int id)
        {
            var itemComentarios = _perRepo.GetComentariosUp(id);

            if (itemComentarios == null)
            {
                return NotFound();
            }
            var itemComentariosDto = _mapper.Map<ComentariosDto>(itemComentarios);

            return Ok(itemComentariosDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ComentariosDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearComentarios([FromBody] CrearComentariosDto tr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (tr == null)
            {
                return BadRequest(ModelState);
            }

            var Comentariosdto = _mapper.Map<Comentarios>(tr);
            if (!_perRepo.CrearComentarios(Comentariosdto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {Comentariosdto.com_comentario}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getComentarios", new { id = Comentariosdto.com_id }, Comentariosdto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarComentarios")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarComentarios(int id, [FromBody] ComentariosDto ComentariosDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (ComentariosDto == null || ComentariosDto.com_id != id)
            {
                return BadRequest(ModelState);
            }

            var cm = _mapper.Map<Comentarios>(ComentariosDto);
            if (!_perRepo.ActualizarComentarios(cm))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {cm.com_comentario}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        //[HttpDelete("{id:int}", Name = "BorrarComentarios")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status403Forbidden)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult BorrarComentarios(int id)
        //{

        //    var per = _perRepo.GetComentariosUp(id);
        //    if (!_perRepo.BorrarComentarios(per))
        //    {
        //        ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.com_comentario}");
        //        return StatusCode(500, ModelState);
        //    }
        //    return NoContent();

        //}

    }
}
