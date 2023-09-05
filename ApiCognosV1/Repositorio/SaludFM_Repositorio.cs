using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class SaludFM_Repositorio : ISaludFM_Repositorio
    {
        private readonly ApplicationDBContext _bd;

        public SaludFM_Repositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }

        public bool ActualizarSalud(SaludFM salud)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            salud.salud_fecha_modificacion= enteredDate;
            _bd.SaludFM.Update(salud);
            return Guardar();
        }

        public bool CrearSalud(SaludFM salud)
        {
            salud.salud_sueno = "<b>Sueño</b>";
            salud.salud_alimentacion = "<b>Alimentación</b>";
            salud.salud_act_fisica = "<b>Alimentación</b>";
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            salud.salud_fecha_captura = enteredDate;
            _bd.SaludFM.Add(salud);
            return Guardar();
        }

        public SaludFM GetSalud(int id)
        {
            return _bd.SaludFM.FirstOrDefault(p => p.salud_paciente_id == id);
        }

        //public bool ActualizarPaciente(Pacientes paciente)
        //{
        //    _bd.Pacientes.Update(paciente);
        //    return Guardar();
        //}

        //public bool CrearPaciente(Pacientes paciente)
        //{
        //    //paciente.pac_paterno= paciente.pac_paterno.ToUpper();
        //    //paciente.pac_materno = paciente.pac_materno.ToUpper();
        //    //paciente.pac_nombre = paciente.pac_nombre.ToUpper();
        //    //paciente.pac_ocupacion = paciente.pac_ocupacion.ToUpper();
        //    //paciente.pac_domicilio = paciente.pac_domicilio.ToUpper();
        //    _bd.Pacientes.Add(paciente);
        //    return Guardar();
        //}

        //public ICollection<Pacientes> GetPacientes()
        //{
        //    return _bd.Pacientes.OrderBy(p => p.pac_paterno).ToList();
        //}

        //public Pacientes GetPacientes(int id)
        //{ return _bd.Pacientes.FirstOrDefault(p => p.pac_id == id);
        //}

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
