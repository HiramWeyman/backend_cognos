using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class EscolaridadRepositorio : IEscolaridadRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public EscolaridadRepositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }
        public bool ActualizarEscolaridad(Escolaridad Escolaridad)
        {

            _bd.Escolaridad.Update(Escolaridad);
            return Guardar();
        }

        public bool BorrarEscolaridad(Escolaridad Escolaridad)
        {
            _bd.Escolaridad.Remove(Escolaridad);
            return Guardar();
        }

        public bool CrearEscolaridad(Escolaridad Escolaridad)
        {
            _bd.Escolaridad.Add(Escolaridad);
            return Guardar();
        }

        public bool ExisteEscolaridad(string desc)
        {
            bool valor = _bd.Escolaridad.Any(p=>p.esc_desc.ToLower().Trim()==desc.ToLower().Trim());
            return valor;
        }

        public bool ExisteEscolaridad(int id)
        {
            bool valor = _bd.Escolaridad.Any(p => p.esc_id== id);
            return valor;
        }

        public ICollection<Escolaridad> GetEscolaridad()
        {
            return _bd.Escolaridad.OrderBy(p=>p.esc_desc).ToList();
        }

        public Escolaridad GetEscolaridad(int id)
        {
            return _bd.Escolaridad.FirstOrDefault(p => p.esc_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges()>=0 ? true:false;
        }
    }
}
