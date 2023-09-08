using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class EvolucionPR_Repositorio : IEvolucionPR_Repositorio
    {
        private readonly ApplicationDBContext _bd;

        public EvolucionPR_Repositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarEvolucion(EvolucionPR evo)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            evo.evo_fecha_modificacion = enteredDate;
            _bd.EvolucionPR.Update(evo);
            return Guardar();
        }

        public bool CrearEvolucion(EvolucionPR evo)
        {
            evo.evo_titulo = "<p style=\"text-align:center\"><b>Evolución del problema.</b></p>";

            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            evo.evo_fecha_captura = enteredDate;
            evo.evo_fecha_modificacion = enteredDate;
            _bd.EvolucionPR.Add(evo);
            return Guardar();
        }

        public EvolucionPR GetEvolucion(int id)
        {
            return _bd.EvolucionPR.FirstOrDefault(p => p.evo_paciente_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
