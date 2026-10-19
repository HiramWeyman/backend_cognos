using ApiCognosV1.Data;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCognosV1.Controllers
{
    [Route("api/ExpedientesTera")]
    [ApiController]
    public class ExpedientesTeraController : ControllerBase
    {

        private readonly ApplicationDBContext _bd;

        public ExpedientesTeraController(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        [HttpGet("GetPacientesPorUsuario/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPacientesPorUsuario(int id)
        {
            var query = from p in _bd.Pacientes
                        where p.pac_usr_id == id && p.eliminado == false
                        orderby p.pac_fecha_ingreso descending
                        select new ExpedientesPacientesDto
                        {
                            pac_id = p.pac_id,
                            nombre = p.pac_paterno + " " + p.pac_materno + " " + p.pac_nombre,
                            pac_fecha_ingreso = p.pac_fecha_ingreso
                        };

            return Ok(query.ToList());
        }

        [HttpGet("GetUsuariosTerapeutas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsuariosTerapeutas()
        {
            var query = from u in _bd.Usuarios
                        where u.usr_per_id == 5 && u.usr_estatus == "A"
                        orderby u.usr_paterno + " " + u.usr_materno + " " + u.usr_nombre
                        select new ExpedientesUsuariosDto
                        {
                            usr_id = u.usr_id,
                            nombre = u.usr_paterno + " " + u.usr_materno + " " + u.usr_nombre
                        };

            return Ok(query.ToList());
        }

    }
}

