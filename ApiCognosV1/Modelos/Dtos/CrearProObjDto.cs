using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class CrearProObjDto
    {
        [Required]
        public string pro_problema { get; set; }

        [Required]
        public string pro_objetivo { get; set; }

        [Required]
        public string pro_tecnica { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime pro_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime pro_fecha_modificacion { get; set; }

        public int pro_paciente_id { get; set; }
  
    }
}
