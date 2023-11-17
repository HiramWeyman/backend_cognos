using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class CreenciaRepositorio : ICreenciasRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public CreenciaRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }
        public bool ActualizarCreencias(Creencias creencia)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            creencia.creencia_fecha_modificacion = enteredDate;
            _bd.Creencias.Update(creencia);
            return Guardar();
        }

        public bool CrearCreencias(Creencias creencia)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            creencia.creencia_fecha_captura = enteredDate;
            creencia.creencia_fecha_modificacion = enteredDate;
            _bd.Creencias.Add(creencia);
            return Guardar();
        }

        public Creencias GetCreencias(int id)
        {
            return _bd.Creencias.FirstOrDefault(p => p.creencia_paciente_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
