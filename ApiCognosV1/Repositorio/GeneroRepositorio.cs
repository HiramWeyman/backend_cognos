using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class GeneroRepositorio : IGeneroRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public GeneroRepositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }
        public bool ActualizarGenero(Genero genero)
        {

            _bd.Genero.Update(genero);
            return Guardar();
        }

        public bool BorrarGenero(Genero genero)
        {
            _bd.Genero.Remove(genero);
            return Guardar();
        }

        public bool CrearGenero(Genero genero)
        {
            _bd.Genero.Add(genero);
            return Guardar();
        }

        public bool ExisteGenero(string desc)
        {
            bool valor = _bd.Genero.Any(p=>p.gen_desc.ToLower().Trim()==desc.ToLower().Trim());
            return valor;
        }

        public bool ExisteGenero(int id)
        {
            bool valor = _bd.Genero.Any(p => p.gen_id== id);
            return valor;
        }

        public ICollection<Genero> GetGenero()
        {
            return _bd.Genero.OrderBy(p=>p.gen_desc).ToList();
        }

        public Genero GetGenero(int id)
        {
            return _bd.Genero.FirstOrDefault(p => p.gen_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges()>=0 ? true:false;
        }
    }
}
