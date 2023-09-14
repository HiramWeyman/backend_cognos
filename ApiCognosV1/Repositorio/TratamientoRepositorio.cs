using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class TratamientoRepositorio: ITratamientoRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public TratamientoRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarTratamiento(Tratamiento tr)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            tr.trata_fecha_modificacion = enteredDate;
            _bd.Tratamiento.Update(tr);
            return Guardar();
        }

        public bool BorrarTratamiento(Tratamiento tr)
        {
            _bd.Tratamiento.Remove(tr);
            return Guardar();
        }

        public bool CrearTratamiento(Tratamiento tr)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            tr.trata_fecha_modificacion = enteredDate;
            tr.trata_fecha_captura = enteredDate;
            _bd.Tratamiento.Add(tr);
            return Guardar();
        }

        public ICollection<Tratamiento> GetTratamiento(int id)
        {
            return _bd.Tratamiento.Where(p => p.trata_paciente_id == id).OrderBy(p => p.trata_id).ToList();
        }

        public Tratamiento GetTratamientoUp(int id)
        {
            return _bd.Tratamiento.FirstOrDefault(p => p.trata_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
