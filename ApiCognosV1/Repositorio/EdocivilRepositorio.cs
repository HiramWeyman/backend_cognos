using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class EdocivilRepositorio : IEdocivilRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public EdocivilRepositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }
        public bool ActualizarEdocivil(Edocivil Edocivil)
        {

            _bd.Edocivil.Update(Edocivil);
            return Guardar();
        }

        public bool BorrarEdocivil(Edocivil Edocivil)
        {
            _bd.Edocivil.Remove(Edocivil);
            return Guardar();
        }

        public bool CrearEdocivil(Edocivil Edocivil)
        {
            _bd.Edocivil.Add(Edocivil);
            return Guardar();
        }

        public bool ExisteEdocivil(string desc)
        {
            bool valor = _bd.Edocivil.Any(p=>p.civil_desc.ToLower().Trim()==desc.ToLower().Trim());
            return valor;
        }

        public bool ExisteEdocivil(int id)
        {
            bool valor = _bd.Edocivil.Any(p => p.civil_id== id);
            return valor;
        }

        public ICollection<Edocivil> GetEdocivil()
        {
            return _bd.Edocivil.OrderBy(p=>p.civil_desc).ToList();
        }

        public Edocivil GetEdocivil(int id)
        {
            return _bd.Edocivil.FirstOrDefault(p => p.civil_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges()>=0 ? true:false;
        }
    }
}
