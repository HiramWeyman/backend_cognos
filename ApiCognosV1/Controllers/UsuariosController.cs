using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepositorio _usuRepo;
        private readonly IMapper _mapper;
        protected RespuestaAPI resp;

        public UsuariosController(IUsuariosRepositorio usuRepo, IMapper mapper)
        {
            _usuRepo = usuRepo;
            _mapper = mapper;
            this.resp = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getUsuarios()
        {
            var listaUsuarios = _usuRepo.GetUsuarios();
            var listaUsuariosDto = new List<UsuariosDto>();
            foreach (var lista in listaUsuarios)
            {

                listaUsuariosDto.Add(_mapper.Map<UsuariosDto>(lista));
            }
            return Ok(listaUsuariosDto);
        }

        [HttpGet("{id:int}", Name = "GetUsuario")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUsuario(int id)
        {
            var itemUsuario = _usuRepo.GetUsuario(id);

            if (itemUsuario == null)
            {
                return NotFound();
            }
            var itemUsuariosDto = _mapper.Map<UsuariosDto>(itemUsuario);

            return Ok(itemUsuariosDto);
        }

        [HttpPost("registro")]
        [ProducesResponseType(201, Type = typeof(UsuariosDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Registro([FromBody] UsuariosRegistroDto usuariosRegistroDto)
        {
            bool validarEmailUnico = _usuRepo.IsUniqueUser(usuariosRegistroDto.usr_email);
            if (!validarEmailUnico) 
            {
                resp.StatusCode = HttpStatusCode.BadRequest;
                resp.IsSuccess = false;
                resp.ErrorMessages.Add("La cuenta de correo ya existe");
                return BadRequest();
            }
            usuariosRegistroDto.usr_paterno = usuariosRegistroDto.usr_paterno.ToUpper();
            usuariosRegistroDto.usr_materno = usuariosRegistroDto.usr_materno.ToUpper();
            usuariosRegistroDto.usr_nombre = usuariosRegistroDto.usr_nombre.ToUpper();
            var usuario = await _usuRepo.Registro(usuariosRegistroDto);
            if (usuario == null)
            {
                resp.StatusCode = HttpStatusCode.BadRequest;
                resp.IsSuccess = false;
                resp.ErrorMessages.Add("Error en el registro");
                return BadRequest();
            }
            resp.StatusCode = HttpStatusCode.OK;
            resp.IsSuccess = true;
            return Ok(resp);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UsuariosLoginDto usuariosLoginDto)
        {
            var respuestaLogin = await _usuRepo.Login(usuariosLoginDto);
 
            if (respuestaLogin.usuario==null|| string.IsNullOrEmpty(respuestaLogin.token)) 
            {
                resp.StatusCode = HttpStatusCode.BadRequest;
                resp.IsSuccess = false;
                resp.ErrorMessages.Add("El Email o password son incorrectos");
                return BadRequest(resp);
            }
      
            resp.StatusCode = HttpStatusCode.OK;
            resp.IsSuccess = true;
            resp.Result = respuestaLogin;
            return Ok(resp);
        }
    }
}
