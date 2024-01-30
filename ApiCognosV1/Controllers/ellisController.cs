using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using XAct;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ellisController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ellisController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;

        }

        [HttpGet]
        [Route("testEllis")]
        public IEnumerable<TestEllis> GetPreguntas()
        {
            return _context.TestEllis.ToList();
        }

        [HttpGet]
        [Route("MaestroEllisList/{Id}")]
        public IEnumerable<Maestro_pruebas> MaestroEllisList(int Id)
        {
            return _context.Maestro_pruebas.Where(e => e.maestro_id_paciente == Id && e.maestro_tipo_prueba == 6).ToList();
        }

        //Ruta para insertar maestro de pruebas
        [HttpPost]
        [Route("MaestroEllis")]
        public IActionResult InsertMaestroEllis(int maestro_id_paciente)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            int idx = 0;
            //var respuesta = new Respuesta();
            if (maestro_id_paciente > 0)
            {
                Console.WriteLine(maestro_id_paciente);
                var objfiles = new Maestro_pruebas()
                {
                    maestro_id = 0,
                    //Name = newFileName,
                    maestro_fecha = enteredDate,
                    maestro_tipo_prueba = 6,
                    maestro_id_paciente = maestro_id_paciente

                };
                _context.Maestro_pruebas.Add(objfiles);
                _context.SaveChanges();
                idx = objfiles.maestro_id;

            }

            return Ok(new { id = idx });
        }


        [HttpGet]
        [Route("testEllisRespuestas/{Id}")]
        public IEnumerable<v_ellis_x> GetRespuestas(int Id)
        {
            return _context.v_ellis.Where(e => e.res_id_maestro == Id).ToList();
        }


        [HttpGet]
        [Route("testEllisTotal/{Id}")]
        public IActionResult GetCount(int Id)
        {
            int totalResp = _context.v_ellis.Where(x => x.res_id_maestro == Id).AsEnumerable().Sum(row => row.res_respuesta);
            return Ok(totalResp);
        }

        [HttpGet]
        [Route("testEllisSuma1/{Id}")]
        public IActionResult GetSuma1(int Id)
        {
            var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (1, 11, 21, 31, 41, 51, 61, 71, 81, 91) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            int valorRes = int.Parse(results[0].ToString());
            return Ok(valorRes);
        }

        [HttpGet]
        [Route("testEllisSuma2/{Id}")]
        public IActionResult GetSuma2(int Id)
        {
            var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (2, 12, 22, 32, 42, 52, 62, 72, 82, 92) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            int valorRes = int.Parse(results[0].ToString());
            return Ok(valorRes);
        }

        [HttpGet]
        [Route("testEllisSuma3/{Id}")]
        public IActionResult GetSuma3(int Id)
        {
            var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (3, 13, 23, 33, 43, 53, 63, 73, 83, 93) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            int valorRes = int.Parse(results[0].ToString());
            return Ok(valorRes);
        }

        [HttpGet]
        [Route("testEllisSuma4/{Id}")]
        public IActionResult GetSuma4(int Id)
        {
            var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (4, 14, 24, 34, 44, 54, 64, 74, 84, 94) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            int valorRes = int.Parse(results[0].ToString());
            return Ok(valorRes);
        }

        [HttpGet]
        [Route("testEllisSuma5/{Id}")]
        public IActionResult GetSuma5(int Id)
        {
            var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (5, 15, 25, 35, 45, 55, 65, 75, 85, 95) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            int valorRes = int.Parse(results[0].ToString());
            return Ok(valorRes);
        }

        [HttpGet]
        [Route("testEllisSuma6/{Id}")]
        public IActionResult GetSuma6(int Id)
        {
            var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (6, 16, 26, 36, 46, 56, 66, 76, 86, 96) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            int valorRes = int.Parse(results[0].ToString());
            return Ok(valorRes);
        }

        [HttpGet]
        [Route("testEllisSuma7/{Id}")]
        public IActionResult GetSuma7(int Id)
        {
            var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (7, 17, 27, 37, 47, 57, 67, 77, 87, 97) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            int valorRes = int.Parse(results[0].ToString());
            return Ok(valorRes);
        }

        [HttpGet]
        [Route("testEllisSuma8/{Id}")]
        public IActionResult GetSuma8(int Id)
        {
            var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (8, 18, 28, 38, 48, 58, 68, 78, 88, 98) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            int valorRes = int.Parse(results[0].ToString());
            return Ok(valorRes);
        }

        [HttpGet]
        [Route("testEllisSuma9/{Id}")]
        public IActionResult GetSuma9(int Id)
        {
            var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (9, 19, 29, 39, 49, 59, 69, 79, 89, 99) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            int valorRes = int.Parse(results[0].ToString());
            return Ok(valorRes);
        }

        [HttpGet]
        [Route("testEllisSuma10/{Id}")]
        public IActionResult GetSuma10(int Id)
        {
            var results = _context.Database.SqlQueryRaw<int>($"SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (10, 20, 30, 40, 50, 60, 70, 80, 90, 100) and [res_id_maestro]=@id", new SqlParameter("@id", Id)).ToList();
            int valorRes = int.Parse(results[0].ToString());
            return Ok(valorRes);
        }

        [HttpPost]
        [Route("testEllisResp")]
        public IActionResult InsertEllisResp(CrearRespEllis[] resp)
        {
            var respuesta = new Respuesta();
            if (resp != null)
            {
                if (resp.Length > 0)
                {
                    //Getting FileName

                    for (int i = 0; i < resp.Length; i++)
                    {

                        Console.WriteLine(resp[i]);
                        var objfiles = new RespEllis()
                        {
                            res_id = 0,
                            //Name = newFileName,
                            res_pregunta = resp[i].res_pregunta,
                            res_respuesta = resp[i].res_respuesta,
                            res_id_paciente = resp[i].res_id_paciente,
                            res_id_maestro= resp[i].res_id_maestro
                        };



                        _context.RespEllis.Add(objfiles);
                        _context.SaveChanges();
                    }

                    respuesta.Descripcion = "Respuestas gurdadas correctamente";

                }
            }

            return Ok(respuesta);
        }

        [HttpDelete]
        [Route("deleteEllisResp/{Id}")]
        public IActionResult DeleteEllisResp(int Id)
        {
            var respuesta = new Respuesta();

            //get the data from the different tables with the id sending from the MVC controller
            var resp = _context.RespEllis.Where(x => x.res_id_paciente == Id).ToList();

            if (resp == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                for (int i = 0; i < resp.Count; i++)
                {
                    _context.RespEllis.Remove(resp[i]);
                    _context.SaveChanges();
                }

                respuesta.Descripcion = "Respuestas eliminadas correctamente";
            }
            return Ok(respuesta);
        }
    }
}
