using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class TerapeutaRepositorio: ITerapeutasRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public TerapeutaRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarTerapeuta(cat_terapeutas terapeuta)
        {
            _bd.cat_terapeutas.Update(terapeuta);
            return Guardar();
        }

        public bool BorrarTerapeuta(cat_terapeutas terapeuta)
        {
            _bd.cat_terapeutas.Remove(terapeuta);
            return Guardar();
        }

        public bool CrearTerapeuta(cat_terapeutas terapeuta)
        {
            _bd.cat_terapeutas.Add(terapeuta);
            return Guardar();
        }

        public cat_terapeutas GetTerapeuta(int id)
        {
            return _bd.cat_terapeutas.FirstOrDefault(p => p.tera_id == id);
        }

        public ICollection<cat_terapeutas> GetTerapeutas()
        {
            return _bd.cat_terapeutas.OrderBy(p => p.tera_paterno).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
