using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class ConsumoSustRepositorio : IConsumoSust_Repositorio
    {
        private readonly ApplicationDBContext _bd;

        public ConsumoSustRepositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }

        public bool ActualizarConsumo(ConsumoSust con)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            con.consumo_fecha_modificacion = enteredDate;
            _bd.ConsumoSust.Update(con);
                return Guardar();
        }

        public bool BorrarConsumo(ConsumoSust con)
        {
            _bd.ConsumoSust.Remove(con);
            return Guardar();
        }

        public bool CrearConsumo(ConsumoSust con)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            con.consumo_fecha_captura = enteredDate;
            con.consumo_fecha_modificacion = enteredDate;
            _bd.ConsumoSust.Add(con);
            return Guardar();
        }

        public ICollection<ConsumoSust> GetConsumoSust(int id)
        {
            return _bd.ConsumoSust.Where(p => p.consumo_paciente_id == id).OrderBy(p => p.consumo_id).ToList();
        }

        public ConsumoSust GetConsumoSustUp(int id)
        {
            return _bd.ConsumoSust.FirstOrDefault(p => p.consumo_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }



}
