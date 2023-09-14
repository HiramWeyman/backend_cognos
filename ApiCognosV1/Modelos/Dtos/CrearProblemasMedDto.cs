using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class CrearProblemasMedDto
    {
      

        public string problema_problema { get; set; }

        public string problema_medico { get; set; }

        public string problema_medicamento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime problema_fecha_ini_trata { get; set; }

        public string problema_tiempo_tratamiento { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime problema_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime problema_fecha_modificacion { get; set; }

   
        public int problema_paciente_id { get; set; }

    }
}
