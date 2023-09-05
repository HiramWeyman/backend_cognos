using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCognosV1.Modelos
{
    public class SaludFM
    {
        [Key]
        public int salud_id { get; set; }
      
        public string salud_sueno { get; set; }

        public string salud_sueno_desc { get; set; }

        public string salud_alimentacion { get; set; }

        public string salud_alimentacion_desc { get; set; }

        public string salud_act_fisica { get; set; }

        public string salud_act_fisica_desc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime salud_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime salud_fecha_modificacion { get; set; }

        [ForeignKey("Pacientes")]
        public int salud_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }

    }
}
