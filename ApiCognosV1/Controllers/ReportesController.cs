using FastReport;
using FastReport.Data;
using FastReport.DataVisualization.Charting;
using FastReport.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using XAct.Users;

namespace ApiCognosV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReportesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("pruebaReporte")]
        public FileResult Generate() {

            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
            FastReport.Utils.Config.WebMode = true;

            Report rep = new Report();

            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string path = "";
            //path = Path.Combine(webRootPath, "Reportes")+"\\prueba1.frx";
            path = contentRootPath + "\\Reportes\\prueba1.frx";
            rep.Load(path);
            //rep.Report.Dictionary.Connections[0].ConnectionString = @"Data Source=iescognos.com;AttachDbFilename=;Initial Catalog=iescogno_expediente;Integrated Security=False;Persist Security Info=True;User ID=iescogno_admin;Password=Weyman1586";

            rep.SetParameterValue("Parameter",3);

            if (rep.Report.Prepare())
            {
                FastReport.Export.PdfSimple.PDFSimpleExport pdfExport = new FastReport.Export.PdfSimple.PDFSimpleExport();
                pdfExport.ShowProgress = false;
                pdfExport.Subject = " Subject Report";
                pdfExport.Title = "Report Title";
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                rep.Report.Export(pdfExport,ms);
                rep.Dispose();
                pdfExport.Dispose();
                ms.Position = 0;
                return File(ms, "application/pdf", "myreport.pdf");

            }
            else {
                return null;
            }
        }
    }
}
