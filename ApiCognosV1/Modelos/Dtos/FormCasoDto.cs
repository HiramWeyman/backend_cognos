using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class FormCasoDto
    {
        public int form_id { get; set; }
        public string form_titulo { get; set; }

        [Required(ErrorMessage = "La Hipótesis es obligatoria")]
        public string form_hipotesis { get; set; }

        [Required(ErrorMessage = "Contraste de hipótesis  es obligatorio")]
        public string form_contraste { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime form_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime form_fecha_modificacion { get; set; }

        [Required(ErrorMessage = "El paciente es obligatorio")]
        public int form_paciente_id { get; set; }

    }
}
