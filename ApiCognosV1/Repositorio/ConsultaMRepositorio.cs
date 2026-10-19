using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class ConsultaMRepositorio:IConsultaMRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public ConsultaMRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarConsulta(ConsultaM cn)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            // Solo se actualiza el motivo del registro existente; el paciente y la
            // fecha de captura nunca se toman del cliente.
            var actual = _bd.ConsultaM.FirstOrDefault(p => p.con_id == cn.con_id);
            if (actual == null || actual.con_paciente_id != cn.con_paciente_id)
            {
                return false;
            }
            actual.con_motivo = cn.con_motivo;
            actual.con_fecha_modificacion = enteredDate;
            return Guardar();
        }

        public bool CrearConsulta(ConsultaM cn)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            cn.con_fecha_captura = enteredDate;
            cn.con_fecha_modificacion = enteredDate;
            _bd.ConsultaM.Add(cn);
            return Guardar();
        }

        public ConsultaM GetConsulta(int id)
        {
            return _bd.ConsultaM.FirstOrDefault(p => p.con_paciente_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
