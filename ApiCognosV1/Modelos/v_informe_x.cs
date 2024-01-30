using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class v_informe_x
    {
        public int inf_id { get; set; }
        public string inf_paterno { get; set; }
        public string inf_materno { get; set; }
        public string inf_nombre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime inf_fecha_nacimiento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime inf_fecha_ingreso { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime inf_ultimo_mov { get; set; }

        public int inf_edad { get; set; }
        public int inf_genero { get; set; }

        public string gen_desc { get; set; }
        public int inf_edocivil { get; set; }

        public string civil_desc { get; set; }

        public string inf_estructura_fam { get; set; }

        public int inf_escolaridad { get; set; }

        public string esc_desc { get; set; }

        
        public string inf_ocupacion { get; set; }

        public string inf_email { get; set; }
        public string inf_telefono { get; set; }
     
        public string inf_domicilio { get; set; }
     
        public int? inf_tutor { get; set; }

        public string supervisor { get; set; }

        public int inf_paciente_id { get; set; }

        public int? inf_terapeuta { get; set; }
        public int? inf_coterapeuta { get; set; }

        //public string terapeuta { get; set; }
        //public string coterapeuta { get; set; }

        
	 
    }
}
