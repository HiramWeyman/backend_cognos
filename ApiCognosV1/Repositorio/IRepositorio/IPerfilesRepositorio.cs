using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IPerfilesRepositorio
    {
        ICollection<Perfiles> GetPerfiles();
        Perfiles GetPerfiles(int id);
        bool ExistePerfil(string desc);
        bool ExistePerfil(int id);
        bool CrearPerfil(Perfiles pefil);
        bool ActualizarPerfil(Perfiles pefil);
        bool BorrarPerfil(Perfiles pefil);
        bool Guardar();
    }
}
