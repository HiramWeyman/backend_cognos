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
    public class EdocivilController : ControllerBase
    {
        private readonly IEdocivilRepositorio _perRepo;
        private readonly IMapper _mapper;

        public EdocivilController(IEdocivilRepositorio perRepo, IMapper mapper)
        {
            _perRepo = perRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getEdocivil() 
        {
            var listaEdocivil=_perRepo.GetEdocivil();
            var listaEdocivilDto = new List<EdocivilDto>();
            foreach (var lista in listaEdocivil) {

                listaEdocivilDto.Add(_mapper.Map<EdocivilDto>(lista));
            }
            return Ok(listaEdocivilDto);
        }

        [HttpGet("{id:int}",Name = "getEdocivil")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getEdocivil(int id)
        {
            var itemEdocivil = _perRepo.GetEdocivil(id);
           
            if (itemEdocivil==null) {
                return NotFound();
            }
            var itemEdocivilsDto = _mapper.Map<EdocivilDto>(itemEdocivil);

            return Ok(itemEdocivilsDto);
        }

        [HttpPost]
        [ProducesResponseType(201,Type =typeof(EdocivilDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearEdocivil([FromBody]CrearEdocivilDto Edocivil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Edocivil==null)
            {
                return BadRequest(ModelState);
            }
            if (_perRepo.ExisteEdocivil(Edocivil.civil_desc)) 
            {
                ModelState.AddModelError("","Este Edocivil ya existe");
                return StatusCode(404, ModelState);
            }
            var Edocivildto = _mapper.Map<Edocivil>(Edocivil);
            if (!_perRepo.CrearEdocivil(Edocivildto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {Edocivildto.civil_desc}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getEdocivil", new { id= Edocivildto.civil_id}, Edocivildto);

        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchEdocivil")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchEdocivil(int id, [FromBody] EdocivilDto EdocivilDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (EdocivilDto== null || EdocivilDto.civil_id!=id)
            {
                return BadRequest(ModelState);
            }
         
            var per= _mapper.Map<Edocivil>(EdocivilDto);
            if (!_perRepo.ActualizarEdocivil(per))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {per.civil_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

        [HttpDelete("{id:int}", Name = "BorrarEdocivil")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BorrarEdocivil(int id)
        {

            if (_perRepo.ExisteEdocivil(id)) 
            {
                return NotFound();
            }

            var per = _perRepo.GetEdocivil(id);
            if (!_perRepo.BorrarEdocivil(per))
            {
                ModelState.AddModelError("", $"Algo slio mal borrando el registro {per.civil_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
    }
}
