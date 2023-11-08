using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface ITerapeutasRepositorio
    {
        ICollection<cat_terapeutas> GetTerapeutas();
        cat_terapeutas GetTerapeuta(int id);
        bool CrearTerapeuta(cat_terapeutas terapeuta);
        bool ActualizarTerapeuta(cat_terapeutas terapeuta);
        bool BorrarTerapeuta(cat_terapeutas terapeuta);
        bool Guardar();
    }
}
