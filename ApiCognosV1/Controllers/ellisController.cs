using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System.Data;
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


        public class SumasResult
        {
            public int Irrac1 { get; set; }
            public int Irrac2 { get; set; }
            public int Irrac3 { get; set; }
            public int Irrac4 { get; set; }
            public int Irrac5 { get; set; }
            public int Irrac6 { get; set; }
            public int Irrac7 { get; set; }
            public int Irrac8 { get; set; }
            public int Irrac9 { get; set; }
            public int Irrac10 { get; set; }
            
        }

        //Cambios del modulo- 

        ///Se onbtienen todas las sumas de acuerdo al id que se le mande
        [HttpGet]
        [Route("getSumasEllis/{resIdMaestro}")]
        public async Task<List<SumasResult>> ObtenerSumasAsync(int resIdMaestro)
        {
            var results = new List<SumasResult>();

            // Reemplaza con tu cadena de conexión real
            string connectionString = "Server=iescognos.com;Database=iescogno_expediente;User Id=iescogno_admin;Password=Weyman1586;TrustServerCertificate=true;MultipleActiveResultSets=true;Trusted_Connection=False;";
            string sqlQuery = @"
                                SELECT
                                (SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (1, 11, 21, 31, 41, 51, 61, 71, 81, 91) and [res_id_maestro] = @resIdMaestro) AS Irrac1,
                                (SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (2, 12, 22, 32, 42, 52, 62, 72, 82, 92) and [res_id_maestro] = @resIdMaestro) AS Irrac2,
                                (SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (3, 13, 23, 33, 43, 53, 63, 73, 83, 93) and [res_id_maestro] = @resIdMaestro) as Irrac3,
                                (SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (4, 14, 24, 34, 44, 54, 64, 74, 84, 94) and [res_id_maestro] = @resIdMaestro) as Irrac4,
                                (SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (5, 15, 25, 35, 45, 55, 65, 75, 85, 95) and [res_id_maestro] = @resIdMaestro) as Irrac5,
                                (SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (6, 16, 26, 36, 46, 56, 66, 76, 86, 96) and [res_id_maestro] = @resIdMaestro) as Irrac6,
                                (SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (7, 17, 27, 37, 47, 57, 67, 77, 87, 97) and [res_id_maestro] = @resIdMaestro) as Irrac7,
                                (SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (8, 18, 28, 38, 48, 58, 68, 78, 88, 98) and [res_id_maestro] = @resIdMaestro) as Irrac8,
                                (SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (9, 19, 29, 39, 49, 59, 69, 79, 89, 99) and [res_id_maestro] = @resIdMaestro) as Irrac9,
                                (SELECT sum([res_respuesta]) FROM [dbo].[Vista_Ellis] where [ellis_id] in (10, 20, 30, 40, 50, 60, 70, 80, 90, 100) and [res_id_maestro]=@resIdMaestro) as Irrac10
                                ";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.Add(new SqlParameter("@resIdMaestro", SqlDbType.Int) { Value = resIdMaestro });

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var result = new SumasResult
                            {
                                Irrac1 = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                Irrac2 = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                                Irrac3 = reader.IsDBNull(2) ? 0 : reader.GetInt32(2),
                                Irrac4 = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                                Irrac5 = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                                Irrac6 = reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                                Irrac7 = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                Irrac8 = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                                Irrac9 = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                                Irrac10 = reader.IsDBNull(9) ? 0 : reader.GetInt32(9)
                            };
                            results.Add(result);
                        }
                    }
                }
            }

            return results;
        }

        //Se eliminan los id y se vuelven ainsertar para mostrarse en el informe
        [HttpDelete]
        [Route("AsignarPruebasEllis")]
        public IActionResult DeleteMostrar(string ids,int prueba,int exp)
        {
            var respuesta = new Respuesta();
            //Primero se eliminan los id maestros que ya esten asignados

            var datos = _context.mostrar_exp.Where(x => x.most_tipo_prueba == prueba && x.most_expediente==exp).ToList();

            for (int i = 0; i < datos.Count; i++)
            {
                _context.mostrar_exp.Remove(datos[i]);
                _context.SaveChanges();
            }
            //Se guardan los id maestros que se quieren mostrar en el expediente
            if (ids != null)
            {
                int[] numbers = ids.Split(',')
                           .Select(int.Parse)
                           .ToArray();

                // Imprimir los números para verificar
                foreach (int number in numbers)
                {
                    Console.WriteLine(number);
                    var objfiles = new mostrar_exp()
                    {
                        most_id = 0,
                        most_id_maestro = number,
                        most_tipo_prueba = prueba,
                        most_expediente = exp,
                    };

                    _context.mostrar_exp.Add(objfiles);
                    _context.SaveChanges();
                   
                }
                respuesta.Descripcion = "Pruebas asignadas a expediente correctamente";
            }

            return Ok(respuesta);
        }
    }
}
