using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class PerfilesRepositorio : IPerfilesRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public PerfilesRepositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }
        public bool ActualizarPerfil(Perfiles pefil)
        {
            _bd.Perfiles.Update(pefil);
            return Guardar();
        }

        public bool BorrarPerfil(Perfiles pefil)
        {
            _bd.Perfiles.Remove(pefil);
            return Guardar();
        }

        public bool CrearPerfil(Perfiles pefil)
        {
            _bd.Perfiles.Add(pefil);
            return Guardar();
        }

        public bool ExistePerfil(string desc)
        {
            bool valor = _bd.Perfiles.Any(p=>p.per_desc.ToLower().Trim()==desc.ToLower().Trim());
            return valor;
        }

        public bool ExistePerfil(int id)
        {
            bool valor = _bd.Perfiles.Any(p => p.per_id== id);
            return valor;
        }

        public ICollection<Perfiles> GetPerfiles()
        {
            return _bd.Perfiles.OrderBy(p=>p.per_desc).ToList();
        }

        public Perfiles GetPerfiles(int id)
        {
            return _bd.Perfiles.FirstOrDefault(p => p.per_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges()>=0 ? true:false;
        }
    }
}
