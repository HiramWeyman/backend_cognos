using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRoleController : ControllerBase
    {
      
        private readonly IUsuariosRepositorio _pacRepo;
        private readonly IMapper _mapper;

        public UsuarioRoleController(IUsuariosRepositorio pacRepo, IMapper mapper)
        {
          
            _pacRepo = pacRepo;
            _mapper = mapper;
        }
        [HttpGet(Name = "getUsuariosRole")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getUsuariosRole(int id)
        {
            var listaUsuarios = _pacRepo.GetUsuariosRole(id);
            var listaUsuariosDto = new List<UsuariosDto>();
            foreach (var lista in listaUsuarios)
            {

                listaUsuariosDto.Add(_mapper.Map<UsuariosDto>(lista));
            }
            return Ok(listaUsuariosDto);

        }
    }
}
