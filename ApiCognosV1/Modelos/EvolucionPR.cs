﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class EvolucionPR
    {
        [Key]
        public int evo_id { get; set; }
        public string evo_titulo { get; set; }

        public string evo_desc { get; set; }
        public string evo_factores{ get; set; }
        public string evo_curso_problema { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime evo_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime evo_fecha_modificacion { get; set; }

        [ForeignKey("Pacientes")]
        public int evo_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}
