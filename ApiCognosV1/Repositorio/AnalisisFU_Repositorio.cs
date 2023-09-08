using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class AnalisisFU_Repositorio : IAnalisisFU_Repositorio
    {
        private readonly ApplicationDBContext _bd;

        public AnalisisFU_Repositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }

        public bool ActualizarAnalisis(AnalisisFU analisis)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            analisis.analisis_fecha_modificacion = enteredDate;
            _bd.AnalisisFU.Update(analisis);
            return Guardar();
        }

        public bool CrearAnalisis(AnalisisFU analisis)
        {
            analisis.analisis_ant= "<b>Antecedentes</b>";
            analisis.analisis_con = "<b>Conducta</b>";
            analisis.analisis_cons = "<b>Consecuentes</b>";
        
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            analisis.analisis_fecha_captura = enteredDate;
            analisis.analisis_fecha_modificacion = enteredDate;
            _bd.AnalisisFU.Add(analisis);
            return Guardar();
        }

        public AnalisisFU GetAnalisis(int id)
        {
            return _bd.AnalisisFU.FirstOrDefault(p => p.analisis_paciente_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
