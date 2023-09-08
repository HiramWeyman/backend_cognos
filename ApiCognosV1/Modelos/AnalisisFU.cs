using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCognosV1.Modelos
{
    public class AnalisisFU
    {
        [Key]
        public int analisis_id { get; set; }
      
        public string analisis_ant { get; set; }

        public string analisis_ant_desc { get; set; }

        public string analisis_con { get; set; }

        public string analisis_con_desc { get; set; }

        public string analisis_cons { get; set; }

        public string analisis_cons_desc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime analisis_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime analisis_fecha_modificacion { get; set; }

        [ForeignKey("Pacientes")]
        public int analisis_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }

    }
}
