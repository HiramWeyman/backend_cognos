using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class DiagnosticoDS_Repositorio : IDiagnosticoDS_Repositorio
    {
        private readonly ApplicationDBContext _bd;

        public DiagnosticoDS_Repositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }

        public bool ActualizarDiagnostico(DiagnosticoDS diag)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            diag.diag_fecha_modificacion = enteredDate;
            _bd.DiagnosticoDS.Update(diag);
            return Guardar();
        }

        public bool CrearDiagnostico(DiagnosticoDS diag)
        {
            diag.diag_titulo = "<p style=\"text-align:center\"><b>Diagnóstico DSMV.</b></p>";

            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            diag.diag_fecha_captura = enteredDate;
            diag.diag_fecha_modificacion = enteredDate;
            _bd.DiagnosticoDS.Add(diag);
            return Guardar();
        }

        public DiagnosticoDS GetDiagnistico(int id)
        {
            return _bd.DiagnosticoDS.FirstOrDefault(p => p.diag_paciente_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
