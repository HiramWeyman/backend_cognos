using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class FormCasoRepositorio: IFormCasoRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public FormCasoRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarFormCaso(FormCaso frm)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            frm.form_fecha_modificacion = enteredDate;
            _bd.FormCaso.Update(frm);
            return Guardar();
        }

        public bool CrearFormCaso(FormCaso frm)
        {
            frm.form_titulo = "<p style=\"text-align:center\"><b>Formulación del Caso .</b></p>";

            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            frm.form_fecha_captura = enteredDate;
            frm.form_fecha_modificacion = enteredDate;
            _bd.FormCaso.Add(frm);
            return Guardar();
        }

        public FormCaso GetFormCaso(int id)
        {
            return _bd.FormCaso.FirstOrDefault(p => p.form_paciente_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
