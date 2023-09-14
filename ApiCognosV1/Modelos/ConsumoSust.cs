﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class ConsumoSust
    {
        [Key]
        public int consumo_id { get; set; }

        public string consumo_sustancia { get; set; }

        public string consumo_sino { get; set; }

        public string consumo_edad_inicio { get; set; }

        public string consumo_cantidad { get; set; }

        public string consumo_tiempo { get; set; }

 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime consumo_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime consumo_fecha_modificacion { get; set; }

        [ForeignKey("Pacientes")]
        public int consumo_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}
