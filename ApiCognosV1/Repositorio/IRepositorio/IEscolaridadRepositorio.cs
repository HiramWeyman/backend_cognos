using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IEscolaridadRepositorio
    {
        ICollection<Escolaridad> GetEscolaridad();
        Escolaridad GetEscolaridad(int id);
        bool ExisteEscolaridad(string desc);
        bool ExisteEscolaridad(int id);
        bool CrearEscolaridad(Escolaridad Escolaridad);
        bool ActualizarEscolaridad(Escolaridad Escolaridad);
        bool BorrarEscolaridad(Escolaridad Escolaridad);
        bool Guardar();
    }
}
