using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class CrearSaludFM_Dto
    {
    

        public string salud_sueno { get; set; }

        [Required(ErrorMessage = "La descripción es obligatorio")]
        public string salud_sueno_desc { get; set; }

        public string salud_alimentacion { get; set; }

        [Required(ErrorMessage = "La descripción es obligatorio")]
        public string salud_alimentacion_desc { get; set; }

        public string salud_act_fisica { get; set; }

        [Required(ErrorMessage = "La descripción es obligatorio")]
        public string salud_act_fisica_desc { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime salud_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime salud_fecha_modificacion { get; set; }

        [Required(ErrorMessage = "El paciente es obligatorio")]
        public int salud_paciente_id { get; set; }
      

    }
}
