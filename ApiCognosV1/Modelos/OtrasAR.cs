using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class OtrasAR
    {
        [Key]
        public int otras_id { get; set; }
        public string otras_titulo { get; set; }

        public string otras_desc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime otras_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime otras_fecha_modificacion { get; set; }

        [ForeignKey("Pacientes")]
        public int otras_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}
