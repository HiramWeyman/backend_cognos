using ApiCognosV1.Modelos.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text.Json.Nodes;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
     
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(EnvioDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult EnviarCorreosPruebas([FromBody] EnvioDto tr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (tr == null)
            {
                return BadRequest(ModelState);
            }
            if (tr.num_prueba == 1) {
                tr.nombre_prueba = "TEST BAI Inventario de Ansiedad de Beck.";
                tr.liga_prueba = "https://pruebas.iescognos.com/testbaian/" + tr.id_pac;
                EnviarCorreoPrueba1(tr.email, tr.id_pac,tr.nombre_prueba,tr.liga_prueba);
            }

            if (tr.num_prueba == 2)
            {
                tr.nombre_prueba = "Test SCL 90 R";
                tr.liga_prueba = "https://pruebas.iescognos.com/inicio/"+ tr.id_pac;
                EnviarCorreoPrueba1(tr.email, tr.id_pac, tr.nombre_prueba, tr.liga_prueba);
            }

            if (tr.num_prueba == 3)
            {
                tr.nombre_prueba = "TEST BDI Inventario de Depresión de Beck.";
                tr.liga_prueba = "https://pruebas.iescognos.com/testbdidp/" + tr.id_pac;
                EnviarCorreoPrueba1(tr.email, tr.id_pac, tr.nombre_prueba, tr.liga_prueba);
            }

            if (tr.num_prueba == 4)
            {
                tr.nombre_prueba = "Test ISRA";
                tr.liga_prueba = "https://pruebas.iescognos.com/testisra/" + tr.id_pac;
                EnviarCorreoPrueba1(tr.email, tr.id_pac, tr.nombre_prueba, tr.liga_prueba);
            }

            if (tr.num_prueba == 5)
            {
                tr.nombre_prueba = "Test SCID2.";
                tr.liga_prueba = "https://pruebas.iescognos.com/testscid/" + tr.id_pac;
                EnviarCorreoPrueba1(tr.email, tr.id_pac, tr.nombre_prueba, tr.liga_prueba);
            }

            if (tr.num_prueba == 6)
            {
                tr.nombre_prueba = "Test Creencias Ellis.";
                tr.liga_prueba = "https://pruebas.iescognos.com/testcreencias/" + tr.id_pac;
                EnviarCorreoPrueba1(tr.email, tr.id_pac, tr.nombre_prueba, tr.liga_prueba);
            }
            tr.mensaje = "Correo Enviado";


            //return NoContent();
            return Ok(tr);

        }


        private void EnviarCorreoPrueba1(string correo,int id_pac,string nombre_prueba,string liga_prueba)
        {

            MailMessage email = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            //email.To.Add(new MailAddress("correo@destino.com"));
            //email.From = new MailAddress("correo@origen.com");
            email.To.Add(new MailAddress(correo));
            email.From = new MailAddress("admin@iescognos.com");
            email.Subject = "Notificación ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
            email.SubjectEncoding = System.Text.Encoding.UTF8;
            email.Body = "<label><b> Favor de ingresar en la siguiente liga para contestar " + nombre_prueba + "</b></label><br><br>" +
                "<a href='"+liga_prueba+ "'> "+nombre_prueba +" "+ id_pac + "</a>"+
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

    }
}
