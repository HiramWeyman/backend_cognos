using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
namespace ApiCognosV1.Repositorio
{
    public class PacientesRepositorio : IPacientesRepositorio
    {
        private readonly ApplicationDBContext _bd;


        public PacientesRepositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }

        public bool ActualizarPaciente(Pacientes paciente)
        {
            _bd.Pacientes.Update(paciente);
            return Guardar();
        }

        public bool CrearPaciente(Pacientes paciente)
        {
            //paciente.pac_paterno= paciente.pac_paterno.ToUpper();
            //paciente.pac_materno = paciente.pac_materno.ToUpper();
            //paciente.pac_nombre = paciente.pac_nombre.ToUpper();
            //paciente.pac_ocupacion = paciente.pac_ocupacion.ToUpper();
            //paciente.pac_domicilio = paciente.pac_domicilio.ToUpper();
            _bd.Pacientes.Add(paciente);
            return Guardar();
        }

        public IEnumerable<Pacientes> GetPacientes()
        {
            try {
                var pacientes = _bd.Pacientes
                 .FromSql($"SELECT * FROM Pacientes")
                 .ToList();
                return pacientes;
                //return _bd.Pacientes.OrderBy(p => p.pac_paterno).ToList();
            }
            catch (Exception e) {
                throw e.InnerException;
            }
           
        }

        public Pacientes GetPacientes(int id)
        { return _bd.Pacientes.FirstOrDefault(p => p.pac_id == id);
        }
         
        public ICollection<Pacientes> GetPacientesList(int id)
        {
            //return _bd.Pacientes.OrderBy(p => p.pac_paterno).ToList();
           
            //return _bd.Pacientes.Where(p => p.pac_tutor == id ).OrderBy(p => p.pac_paterno).ToList();
           return _bd.Pacientes.Where(l => l.pac_tutor == id || l.pac_usr_id == id).OrderBy(p => p.pac_paterno).ToList();

        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
