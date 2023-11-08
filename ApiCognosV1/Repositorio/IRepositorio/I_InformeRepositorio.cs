using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface I_InformeRepositorio
    {
        //ICollection<Informe> GetInforme();

        ICollection<Informe> GetInformeList(int id);
        Informe GetInforme(int id);
        //bool ExistePerfil(string desc);
        //bool ExistePerfil(int id);
        bool CrearPaciente(Informe paciente);
       // bool ActualizarPaciente(Informe paciente);
        //bool BorrarPaciente(Informe paciente);
        bool Guardar();
    }
}
