using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class InformeRepositorio: I_InformeRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public InformeRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool CrearPaciente(Informe paciente)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd h:m:s tt");
            DateTime enteredDate = DateTime.Parse(dateString2);
            paciente.inf_ultimo_mov = enteredDate;
            _bd.Informe.Add(paciente);
            return Guardar();
        }

        public Informe GetInforme(int id)
        {
            return _bd.Informe.FirstOrDefault(p => p.inf_id == id);
        }

        public ICollection<Informe> GetInformeList(int id)
        {
            return _bd.Informe.Where(p => p.inf_paciente_id == id).OrderBy(p => p.inf_ultimo_mov).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
