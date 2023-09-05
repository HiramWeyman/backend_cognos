using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface ISaludFM_Repositorio
    {

        SaludFM GetSalud(int id);
        //bool ExistePerfil(string desc);
        //bool ExistePerfil(int id);
        bool CrearSalud(SaludFM salud);
        bool ActualizarSalud(SaludFM salud);
        //bool BorrarPaciente(Pacientes paciente);
        bool Guardar();

    }
}
