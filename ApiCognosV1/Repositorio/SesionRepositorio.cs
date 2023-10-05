using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class SesionRepositorio: ISesionRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public SesionRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarSesion(Sesion se)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            se.sesion_fecha_modificacion = enteredDate;
            _bd.Sesion.Update(se);
            return Guardar();
        }

        public bool BorrarSesion(Sesion se)
        {
            _bd.Sesion.Remove(se);
            return Guardar();
        }

        public bool CrearSesion(Sesion se)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            se.sesion_fecha_modificacion = enteredDate;
            se.sesion_fecha_captura = enteredDate;
            _bd.Sesion.Add(se);
            return Guardar();
        }

        public ICollection<Sesion> GetSesion(int id)
        {
            return _bd.Sesion.Where(p => p.sesion_paciente_id == id).OrderBy(p => p.sesion_no).ToList();
        }

        public Sesion GetSesionUp(int id)
        {
            return _bd.Sesion.FirstOrDefault(p => p.sesion_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
