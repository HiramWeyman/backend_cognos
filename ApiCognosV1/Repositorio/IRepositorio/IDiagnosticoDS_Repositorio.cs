using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IDiagnosticoDS_Repositorio
    {
        DiagnosticoDS GetDiagnistico(int id);
        bool CrearDiagnostico(DiagnosticoDS diag);
        bool ActualizarDiagnostico(DiagnosticoDS diag);
        bool Guardar();
    }
}
