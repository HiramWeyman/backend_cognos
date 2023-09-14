using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class PrevioSaludDto
    {
     
        public int previo_id { get; set; }

        public string previo_problema { get; set; }

        public string previo_medico { get; set; }

        public string previo_medicamento { get; set; }

        public string previo_tiempo_tratamiento { get; set; }

        public string previo_tiempo_psicologico { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime previo_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime previo_fecha_modificacion { get; set; }
        public int previo_paciente_id { get; set; }
 
    }
}
