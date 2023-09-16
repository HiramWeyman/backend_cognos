using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class ConsultaM
    {
        [Key]
        public int con_id { get; set; }
        [Required]
        public string con_motivo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime con_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime con_fecha_modificacion { get; set; }

        [ForeignKey("Pacientes")]
        public int con_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}
