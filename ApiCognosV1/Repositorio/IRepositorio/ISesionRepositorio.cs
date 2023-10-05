using ApiCognosV1.Modelos;
namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface ISesionRepositorio
    {
        ICollection<Sesion> GetSesion(int se);
        Sesion GetSesionUp(int id);
        bool CrearSesion(Sesion se);
        bool ActualizarSesion(Sesion se);
        bool BorrarSesion(Sesion se);
        bool Guardar();
    }
}
