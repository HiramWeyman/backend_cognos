using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class ProbObjRepositorio: IProbObjRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public ProbObjRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarProbObj(ProbObj po)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            po.pro_fecha_modificacion = enteredDate;
            _bd.ProbObj.Update(po);
            return Guardar();
        }

        public bool BorrarProbObj(ProbObj po)
        {
            _bd.ProbObj.Remove(po);
            return Guardar();
        }

        public bool CrearProbObj(ProbObj po)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            po.pro_fecha_modificacion = enteredDate;
            po.pro_fecha_captura = enteredDate;
            _bd.ProbObj.Add(po);
            return Guardar();
        }

        public ICollection<ProbObj> GetProbObj(int id)
        {
            return _bd.ProbObj.Where(p => p.pro_paciente_id == id).OrderBy(p => p.pro_id).ToList();
        }

        public ProbObj GetProbObjUp(int id)
        {
            return _bd.ProbObj.FirstOrDefault(p => p.pro_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
