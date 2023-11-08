using ApiCognosV1.Data;
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
    public class VistaInformeController : ControllerBase
    {
        //private readonly ISesionRepositorio _perRepo;
        //private readonly IMapper _mapper;
        private readonly ApplicationDBContext _bd;

        public VistaInformeController(
            //ISesionRepositorio perRepo, 
            //IMapper mapper,
            ApplicationDBContext bd)
        {
            //_perRepo = perRepo;
            //_mapper = mapper;
            _bd = bd;
        }



        [HttpGet("{id:int}", Name = "getVistaInforme")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getVistaInforme(int id)
        {
            //var propertyName = "sesion_id";
            //var propertyValue = 2;

            //var blogs = _bd.v_sesion
            //    .FromSql($" select * from v_sesiones WHERE sesion_id=4")
            //    .ToList();
            //var p1 = new SqlParameter("@Id", id);
            //var author = _bd.v_sesion.FromSqlRaw($"select * from v_sesiones WHERE sesion_id = @Id", p1).FirstOrDefault();
            var user = _bd.v_informe.FirstOrDefault(x => x.inf_id == id);

            return Ok(user);
        }

    }
}
