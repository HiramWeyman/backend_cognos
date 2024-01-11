using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XAct;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacPerilesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PacPerilesController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;

        }

        [HttpGet]
        [Route("pacientesR1/{Id}")]
        public IEnumerable<Pacientes> GetPacR1(int Id)
        {
            return _context.Pacientes.Where(e => e.pac_usr_id == Id).ToList();
        }

        [HttpGet]
        [Route("pacientesR2")]
        public IEnumerable<Pacientes> GetPacR2()
        {
            var pacientes = _context.Pacientes
                  .FromSql($"SELECT [pac_id]\r\n      ,[pac_paterno]\r\n      ,[pac_materno]\r\n      ,[pac_nombre]\r\n      ,[pac_fecha_nacimiento]\r\n      ,[pac_fecha_ingreso]\r\n      ,[pac_edad]\r\n      ,[pac_genero]\r\n      ,[pac_edocivil]\r\n      ,[pac_escolaridad]\r\n      ,[pac_ocupacion]\r\n      ,[pac_email]\r\n      ,[pac_telefono]\r\n      ,[pac_domicilio]\r\n      ,[pac_usr_id]\r\n      ,[pac_tutor]\r\n      ,[pac_coterapeuta]\r\n      ,[pac_terapeuta]\r\n      ,[pac_estructura_fam]\r\n  FROM [iescogno_expediente].[dbo].[Pacientes],[dbo].[Usuarios] where [pac_usr_id]=[usr_id] and [usr_per_id] in(2,3) ")
                  .ToList();
            return pacientes;
        }

        [HttpGet]
        [Route("pacientesTerapeutas")]
        public IEnumerable<Pacientes> GetPacTera(int Id)
        {
            return _context.Pacientes.Where(e => e.pac_usr_id == Id).ToList();
        }
    }
}
