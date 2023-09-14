using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface ITratamientoRepositorio
    {
        ICollection<Tratamiento> GetTratamiento(int id);
        Tratamiento GetTratamientoUp(int id);
        bool CrearTratamiento(Tratamiento tr);
        bool ActualizarTratamiento(Tratamiento tr);
        bool BorrarTratamiento(Tratamiento tr);
        bool Guardar();
    }
}
