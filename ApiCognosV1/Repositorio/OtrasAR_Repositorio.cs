using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Modelos.Dtos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class OtrasAR_Repositorio : IOtrasAR_Repositorio
    {
        private readonly ApplicationDBContext _bd;

        public OtrasAR_Repositorio(ApplicationDBContext bd)
        {
                _bd = bd;
        }

        public bool ActualizarOtras(OtrasAR otras)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            otras.otras_fecha_modificacion = enteredDate;
            _bd.OtrasAR.Update(otras);
            return Guardar();
        }

        public bool CrearOtras(OtrasAR otras)
        {
            otras.otras_titulo = "<p style=\"text-align:center\"><b>Otras áreas a considerar.</b></p>";
            otras.otras_desc = "<p style=\"text-align:center\"><b>Otras áreas a considerar.</b></p>";
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            otras.otras_fecha_captura = enteredDate;
            otras.otras_fecha_modificacion = enteredDate;
            _bd.OtrasAR.Add(otras);
            return Guardar();
        }

        public OtrasAR GetOtras(int id)
        {
            return _bd.OtrasAR.FirstOrDefault(p => p.otras_paciente_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
