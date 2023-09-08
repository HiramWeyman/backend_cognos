using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IEvolucionPR_Repositorio
    {
        EvolucionPR GetEvolucion(int id);
      
        bool CrearEvolucion(EvolucionPR evo);
        bool ActualizarEvolucion(EvolucionPR evo);
        //bool BorrarPaciente(Pacientes paciente);
        bool Guardar();
    }
}
