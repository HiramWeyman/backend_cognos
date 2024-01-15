using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XAct;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtrasController : ControllerBase
    {
        private readonly IOtrasAR_Repositorio _pacRepo;
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _context;

        public OtrasController(ApplicationDBContext context, IOtrasAR_Repositorio pacRepo, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;

            _context = context;
        }

        [HttpGet("{id:int}", Name = "getOtras")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getOtras(int id)
        {
            var itemOtras = _pacRepo.GetOtras(id);

            if (itemOtras == null)
            {
                return NotFound();
            }
            var itemOtrasDto = _mapper.Map<OtrasAR_Dto>(itemOtras);

            return Ok(itemOtrasDto);
        }

        [HttpPost]
        [Route("CrearOtras")]
        //[ProducesResponseType(201, Type = typeof(OtrasAR_Dto))]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearOtras([FromBody] CrearOtrasAR_Dto otras)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            var respuesta = new Respuesta();
            if (otras != null)
            {
                Console.WriteLine(otras);
                var objfiles = new OtrasAR()
                {
                    otras_id = 0,
                    otras_titulo = "Otras areas a Considerar",
                    otras_desc = "Desc Otras areas a Considerar",
                    otras_autocontrol = otras.otras_autocontrol,
                    otras_aspectos_m = otras.otras_aspectos_m,
                    otras_recursos_p = otras.otras_recursos_p,
                    otras_apoyo_s = otras.otras_apoyo_s,
                    otras_situacion_v = otras.otras_situacion_v,
                    otras_fecha_captura = enteredDate,
                    otras_fecha_modificacion = enteredDate,
                    otras_paciente_id = otras.otras_paciente_id,

                };



                _context.OtrasAR.Add(objfiles);
                _context.SaveChanges();
                respuesta.Descripcion = "Respuestas gurdadas correctamente";

            }
            return Ok(respuesta);
        }

        [HttpPatch("{id:int}", Name = "ActualizarPatchOtras")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchOtras(int id, [FromBody] OtrasAR_Dto otrasDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (otrasDto == null || otrasDto.otras_id != id)
            {
                return BadRequest(ModelState);
            }

            var otras = _mapper.Map<OtrasAR>(otrasDto);
            if (!_pacRepo.ActualizarOtras(otras))
            {
                ModelState.AddModelError("", $"Algo slio mal actualizando el registro {otras.otras_desc}");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }

    }
}
