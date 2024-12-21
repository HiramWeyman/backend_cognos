using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using System.IO;
using System.Threading.Tasks;


namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepController : ControllerBase
    {


        [HttpPost("combinar")]
        public async Task<IActionResult> CombinePdfs(IFormFileCollection files, [FromForm] string nombre)
        {
            // Validar que se recibieron los archivos
            if (files.Count != 2)
            {
                return BadRequest("Se deben enviar exactamente dos archivos PDF.");
            }

            using (var outputMemoryStream = new MemoryStream())
            {
                // Crear un documento PDF vacío
                var outputPdf = new PdfDocument();

                // Procesar los archivos PDF enviados
                foreach (var file in files)
                {
                    if (file.ContentType != "application/pdf")
                    {
                        return BadRequest("Solo se permiten archivos PDF.");
                    }

                    using (var stream = file.OpenReadStream())
                    {
                        var pdfDoc = PdfReader.Open(stream, PdfDocumentOpenMode.Import);

                        // Copiar todas las páginas del archivo PDF al PDF de salida
                        foreach (var page in pdfDoc.Pages)
                        {
                            outputPdf.AddPage(page);
                        }
                    }
                }

                // Guardar el PDF combinado en el MemoryStream
                outputPdf.Save(outputMemoryStream, false);

                // Retornar el archivo PDF combinado al frontend
                return File(outputMemoryStream.ToArray(), "application/pdf", $"{nombre}");
            }


        }

    }
}
