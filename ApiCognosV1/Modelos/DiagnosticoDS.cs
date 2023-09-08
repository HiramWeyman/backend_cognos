using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class DiagnosticoDS
    {
        [Key]
        public int diag_id { get; set; }
        public string diag_titulo { get; set; }

        public string diag_desc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime diag_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime diag_fecha_modificacion { get; set; }

        [ForeignKey("Pacientes")]
        public int diag_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}
