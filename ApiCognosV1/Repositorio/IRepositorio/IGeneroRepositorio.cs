using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IGeneroRepositorio
    {
        ICollection<Genero> GetGenero();
        Genero GetGenero(int id);
        bool ExisteGenero(string desc);
        bool ExisteGenero(int id);
        bool CrearGenero(Genero genero);
        bool ActualizarGenero(Genero genero);
        bool BorrarGenero(Genero genero);
        bool Guardar();
    }
}
