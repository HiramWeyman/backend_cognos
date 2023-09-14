using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class ProblemasMedRepositorio : IProblemasMed_Repositorio
    {
        private readonly ApplicationDBContext _bd;

        public ProblemasMedRepositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }

        public bool ActualizarProblemas(ProblemasMed prob)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            prob.problema_fecha_modificacion = enteredDate;
            _bd.ProblemasMed.Update(prob);
               return Guardar();
        }

        public bool BorrarProblema(ProblemasMed prob)
        {
            _bd.ProblemasMed.Remove(prob);
            return Guardar();
        }

        public bool CrearProblema(ProblemasMed prob)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            prob.problema_fecha_captura= enteredDate;
            prob.problema_fecha_modificacion = enteredDate;
            _bd.ProblemasMed.Add(prob);
            return Guardar();
        }

        public ICollection<ProblemasMed> GetProblemasMed(int id)
        {
            return _bd.ProblemasMed.Where(p => p.problema_paciente_id==id).OrderBy(p => p.problema_id).ToList();
        }

        public ProblemasMed GetProblemasMedUp(int id)
        {
            return _bd.ProblemasMed.FirstOrDefault(p => p.problema_id == id);
        }



        public bool Guardar()
        {
            return _bd.SaveChanges()>=0 ? true:false;
        }
    }
}
