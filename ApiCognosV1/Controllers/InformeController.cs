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
    public class InformeController : ControllerBase
    {
        private readonly I_InformeRepositorio _pacRepo;
        private readonly IMapper _mapper;

        public InformeController(I_InformeRepositorio pacRepo, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _mapper = mapper;
        }


        [HttpGet(Name = "getInformeList")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getInformeList(int id)
        {
            var listaInformes = _pacRepo.GetInformeList(id);
            var listaInformeDto = new List<InformeDto>();
            foreach (var lista in listaInformes)
            {

                listaInformeDto.Add(_mapper.Map<InformeDto>(lista));
            }
            return Ok(listaInformeDto);
        }



        [HttpGet("{id:int}", Name = "getInforme")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getInforme(int id)
        {
            var itemPaciente = _pacRepo.GetInforme(id);

            if (itemPaciente == null)
            {
                return NotFound();
            }
            var itemPacienteDto = _mapper.Map<InformeDto>(itemPaciente);

            return Ok(itemPacienteDto);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(InformeDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CrearInforme([FromBody] CrearInformeDto paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (paciente == null)
            {
                return BadRequest(ModelState);
            }
      
            var pacientedto = _mapper.Map<Informe>(paciente);
            if (!_pacRepo.CrearPaciente(pacientedto))
            {
                ModelState.AddModelError("", $"Algo slio mal guardando el registro {pacientedto.inf_paterno}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("getInforme", new { id = pacientedto.inf_id }, pacientedto);

        }
    }
}
