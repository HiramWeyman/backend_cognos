using ApiCognosV1.Data;
using ApiCognosV1.Modelos.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using ApiCognosV1.Modelos;
using XSystem.Security.Cryptography;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecuperaPassController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public RecuperaPassController(IMapper mapper, ApplicationDBContext context)
        {
            //_pacRepo = pacRepo;
            _context = context;

        }

        [HttpGet]
        [Route("ValidaMail/{correo}")]
        public IActionResult GetCount(string correo)
        {
            int totalResp = _context.Usuarios.Where(x => x.usr_email == correo).AsEnumerable().Count();
            return Ok(totalResp);
        }

        [HttpPost]
        [Route("EnvioMail")]
        public IActionResult EnviarCorreos(string email)
        {
            var respuesta = new Respuesta();
            var liga_prueba = "https://pruebas.iescognos.com/recupera/" + email;
            EnviarCorreo(email,liga_prueba);
            respuesta.Descripcion = "Correo enviado correctamente";
            return Ok(respuesta);

        }


        private void EnviarCorreo(string correo, string liga_prueba)
        {

            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient();
     
            //email.To.Add(new MailAddress("correo@destino.com"));
            //email.From = new MailAddress("correo@origen.com");
            email.To.Add(new MailAddress(correo));
            email.From = new MailAddress("admin@iescognos.com");
            email.Subject = "Notificación ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = "<label><b> Favor de ingresar en la siguiente liga para recuperar password </b></label><br><br>" +
                "<a href='" + liga_prueba + "'>Recuperar password</a>" +
                "<br><br><label><b> Gracias por su Atención.<b></label><br><br> " +
                "<label><b>Atentamente.<b></label><br><br>" +
                "<label><b>COGNOS Centro de Terapia Cognitivo Conductal de Durango.</b></label>";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            //FileStream fs = new FileStream("E:\\TestFolder\\test.pdf", FileMode.Open, FileAccess.Read);
            //Attachment a = new Attachment(fs, "test.pdf", MediaTypeNames.Application.Octet);
            //email.Attachments.Add(a);
            smtp.Host = "mail.iescognos.com";
            // smtp.Host = "192.XXX.X.XXX";  // IP empresa/institucional
            //smtp.Host = "smtp.hotmail.com";
            //smtp.Host = "smtp.gmail.com";
            // smtp.Port = 25;
            smtp.Port = 587;
            smtp.Timeout = 100000;
            smtp.EnableSsl = false;
            //smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;

            //smtp.Credentials = new NetworkCredential("correo@origen.com", "password");
            smtp.Credentials = new NetworkCredential("admin@iescognos.com", "Weyman1586");

            string lista = "ejemplo1@correo.com; ejemplo2@correo2.com;";
            string output = "";
            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Correo electrónico fue enviado satisfactoriamente.";
            }
            catch (SmtpException exm)
            {
                throw exm;
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }

        }


        [HttpPatch]
        [Route("UpdPass")]
        public IActionResult UpdatePass(string email, string password)
        {
            var respuesta = new Respuesta();
            var passwordEncriptado = obtenerMD5(password);
            Usuarios resp = _context.Usuarios.Where(x => x.usr_email == email).FirstOrDefault();

            if (resp == null)
            {
                respuesta.Descripcion = "El registro no se encontro";
                return Ok(respuesta);
            }
            else
            {
                resp.usr_password = passwordEncriptado;
                _context.Usuarios.Update(resp);
                _context.SaveChanges();

                respuesta.Descripcion = "Su password se cambio correctamente";
            }
       
           
            return Ok(respuesta);

        }

        public static string obtenerMD5(string valor)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }
    }
}
