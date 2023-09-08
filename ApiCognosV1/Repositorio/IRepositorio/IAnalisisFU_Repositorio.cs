using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IAnalisisFU_Repositorio
    {

       AnalisisFU GetAnalisis(int id);
        //bool ExistePerfil(string desc);
        //bool ExistePerfil(int id);
        bool CrearAnalisis(AnalisisFU analisis);
        bool ActualizarAnalisis(AnalisisFU analisis);
        //bool BorrarPaciente(Pacientes paciente);
        bool Guardar();

    }
}
