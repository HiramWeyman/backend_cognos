using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class LineaVidaRepositorio : ILineaVidaRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public LineaVidaRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }
        public bool ActualizarLineaVida(LineaVida tr)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            tr.lin_fecha_modificacion = enteredDate;
            _bd.LineaVida.Update(tr);
            return Guardar();
        }

        public bool BorrarLineaVida(LineaVida tr)
        {
            _bd.LineaVida.Remove(tr);
            return Guardar();
        }

        public bool CrearLineaVida(LineaVida tr)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            tr.lin_fecha_modificacion = enteredDate;
            tr.lin_fecha_captura = enteredDate;
            _bd.LineaVida.Add(tr);
            return Guardar();
        }

        public ICollection<LineaVida> GetLineaVida(int id)
        {
            return _bd.LineaVida.Where(p => p.lin_paciente_id == id).OrderBy(p => p.lin_id).ToList();
        }

        public LineaVida GetLineaVidaUp(int id)
        {
            return _bd.LineaVida.FirstOrDefault(p => p.lin_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
