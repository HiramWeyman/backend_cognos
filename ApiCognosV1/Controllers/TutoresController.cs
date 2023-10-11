using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutoresController : ControllerBase
    {
        private readonly IPacientesRepositorio _pacRepo;
        private readonly IUsuariosRepositorio _pacRepo2;
        private readonly IMapper _mapper;

        public TutoresController(IPacientesRepositorio pacRepo, IUsuariosRepositorio pacRepo2, IMapper mapper)
        {
            _pacRepo = pacRepo;
            _pacRepo2 = pacRepo2;
            _mapper = mapper;
        }
        [HttpGet(Name = "getPacientesList")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getPacientesList(int id)
        {
            var listaPaciente = _pacRepo.GetPacientesList(id);
            var listaPacienteDto = new List<PacientesDto>();
            foreach (var lista in listaPaciente)
            {

                listaPacienteDto.Add(_mapper.Map<PacientesDto>(lista));
            }
            return Ok(listaPacienteDto);

        }

  
    }
}
