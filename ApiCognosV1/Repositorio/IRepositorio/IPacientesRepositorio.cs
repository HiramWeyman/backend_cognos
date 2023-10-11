using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IPacientesRepositorio
    {
        ICollection<Pacientes> GetPacientes();

        ICollection<Pacientes> GetPacientesList(int id);
        Pacientes GetPacientes(int id);
        //bool ExistePerfil(string desc);
        //bool ExistePerfil(int id);
        bool CrearPaciente(Pacientes paciente);
        bool ActualizarPaciente(Pacientes paciente);
        //bool BorrarPaciente(Pacientes paciente);
        bool Guardar();

    }
}
