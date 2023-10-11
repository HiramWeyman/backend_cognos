using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ApiCognosV1.Modelos
{
    public class FormCaso
    {
        [Key]
        public int form_id { get; set; }
        public string form_titulo { get; set; }
        public string form_hipotesis { get; set; }
        public string form_contraste { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime form_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime form_fecha_modificacion { get; set; }

        [ForeignKey("Pacientes")]
        public int form_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}
