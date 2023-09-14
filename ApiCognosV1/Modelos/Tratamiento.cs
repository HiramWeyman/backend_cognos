using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCognosV1.Modelos
{
    public class Tratamiento
    {
        [Key]
        public int trata_id { get; set; }
        [Required]
        public string trata_objetivo { get; set; }

        [Required]
        public string trata_tecnica { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime trata_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime trata_fecha_modificacion { get; set; }

        [ForeignKey("Pacientes")]
        public int trata_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}
