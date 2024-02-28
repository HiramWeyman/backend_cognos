using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using XAct.Library.Settings;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VistaController : ControllerBase
    {
        private readonly ISesionRepositorio _perRepo;
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _bd;

        public VistaController(ISesionRepositorio perRepo, IMapper mapper, ApplicationDBContext bd)
        {
            _perRepo = perRepo;
            _mapper = mapper;
            _bd = bd;
        }



        [HttpGet("{id:int}", Name = "getVista")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getVista(int id)
        {
            //var propertyName = "sesion_id";
            //var propertyValue = 2;

            //var blogs = _bd.v_sesion
            //    .FromSql($" select * from v_sesiones WHERE sesion_id=4")
            //    .ToList();
            //var p1 = new SqlParameter("@Id", id);
            //var author = _bd.v_sesion.FromSqlRaw($"select * from v_sesiones WHERE sesion_id = @Id", p1).FirstOrDefault();
            var user = _bd.Sesion.FirstOrDefault(x => x.sesion_id == id);

            return Ok(user);
        }

        [HttpGet]
        [Route("v_terapeuta")]
        public IActionResult GetTerapeuta(int id)
        {
            var user = _bd.cat_terapeutas.FirstOrDefault(x => x.tera_id == id);

            return Ok(user);
        }

        [HttpGet]
        [Route("v_coterapeuta")]
        public IActionResult GetCoTerapeuta(int id)
        {
            var user = _bd.cat_terapeutas.FirstOrDefault(x => x.tera_id == id);

            return Ok(user);
        }

        //[HttpGet]
        //[Route("v_tarea")]
        //public IActionResult GetTarea(int id)
        //{
        //    var user = _bd.cat_.FirstOrDefault(x => x.tera_id == id);

        //    return Ok(user);
        //}

    }
}
