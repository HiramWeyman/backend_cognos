using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IComentariosRepositorio
    {
        ICollection<Comentarios> GetComentarios(int idx,int id_paciente);
        Comentarios GetComentariosUp(int id);
        bool CrearComentarios(Comentarios com);
        bool ActualizarComentarios(Comentarios com);
        bool BorrarComentarios(Comentarios com);
        bool Guardar();
    }
}
