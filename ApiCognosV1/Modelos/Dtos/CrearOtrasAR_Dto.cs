﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class CrearOtrasAR_Dto
    {
        
        public string otras_titulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string otras_desc { get; set; }

        public string otras_autocontrol { get; set; }

        public string otras_aspectos_m { get; set; }

        public string otras_recursos_p { get; set; }

        public string otras_apoyo_s { get; set; }

        public string otras_situacion_v { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime otras_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime otras_fecha_modificacion { get; set; }

        [Required(ErrorMessage = "El paciente es obligatorio")]
        public int otras_paciente_id { get; set; }
 
    }
}
