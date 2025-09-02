using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class Maestro_pruebas_hist
    {
        [Key]
        public int maestro_id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime maestro_fecha { get; set; }

        public int maestro_tipo_prueba { get; set; }

        public int maestro_id_paciente { get; set; }

        public int? maestro_id_imagen { get; set; }

        public string maestro_observacion { get; set; }

        public bool maestro_eliminado { get; set; }
    }
}
