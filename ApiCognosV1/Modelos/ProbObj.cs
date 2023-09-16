using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCognosV1.Modelos
{
    public class ProbObj
    {
        [Key]
        public int pro_id { get; set; }
        [Required]
        public string pro_problema { get; set; }

        [Required]
        public string pro_objetivo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime pro_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime pro_fecha_modificacion { get; set; }

        [ForeignKey("Pacientes")]
        public int pro_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}
