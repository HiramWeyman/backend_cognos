using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class EvolucionPR_Dto
    {
       
        public int evo_id { get; set; }
        public string evo_titulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string evo_desc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime evo_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime evo_fecha_modificacion { get; set; }

        [Required(ErrorMessage = "El paciente es obligatorio")]
        public int evo_paciente_id { get; set; }

    }
}
