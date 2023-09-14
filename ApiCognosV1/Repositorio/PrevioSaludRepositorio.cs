using ApiCognosV1.Data;
using ApiCognosV1.Migrations;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class PrevioSaludRepositorio : IPrevioSalud_Repositorio
    {
        private readonly ApplicationDBContext _bd;

        public PrevioSaludRepositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }

        public bool ActualizarPrevio(PrevioSalud pre)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            pre.previo_fecha_modificacion = enteredDate;
            _bd.PrevioSalud.Update(pre);
                return Guardar();
        }

        public bool BorrarPrevio(PrevioSalud pre)
        {
                _bd.PrevioSalud.Remove(pre);
                return Guardar();
        }

        public bool CrearPrevio(PrevioSalud pre)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            pre.previo_fecha_captura = enteredDate;
            pre.previo_fecha_modificacion = enteredDate;
            _bd.PrevioSalud.Add(pre);
                return Guardar();
        }

        public ICollection<PrevioSalud> GetPrevioSalud(int id)
        {
            return _bd.PrevioSalud.Where(p => p.previo_paciente_id == id).OrderBy(p => p.previo_id).ToList();
        }

        public PrevioSalud GetPrevioSaludUp(int id)
        {
            return _bd.PrevioSalud.FirstOrDefault(p => p.previo_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }



}
