using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IUsuariosRepositorio
    {
        ICollection<Usuarios> GetUsuarios();

        ICollection<Usuarios> GetUsuariosRole(int id);
        Usuarios GetUsuario(int id);
        bool IsUniqueUser(string email);
        Task<UsuarioLoginRespuestaDto> Login(UsuariosLoginDto usuariosLoginDto);
        Task<Usuarios> Registro(UsuariosRegistroDto usuariosRegistroDto);
        //bool ExisteUsuario(int id);
        //bool CrearPerfil(Usuarios usuario);
        //bool ActualizarUsuario(Usuarios usuario);
        //bool BorrarPerfil(Usuarios usuario);
        //bool Guardar();
    }
}
