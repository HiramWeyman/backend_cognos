using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class LineaVida
    {
        [Key]
        public int lin_id { get; set; }
        [Required]
        public string lin_titulo { get; set; }

        [Required]
        public string lin_desc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime lin_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime lin_fecha_modificacion { get; set; }

        [ForeignKey("Pacientes")]
        public int lin_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}
