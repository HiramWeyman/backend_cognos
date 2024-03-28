using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ApiCognosV1.Modelos.Dtos
{
    public class InformeDto
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
        public int inf_edocivil { get; set; }

        public string inf_estructura_fam { get; set; }
        public int inf_escolaridad { get; set; }
        public string inf_ocupacion { get; set; }
        public string inf_email { get; set; }
        public string inf_telefono { get; set; }
        public string inf_domicilio { get; set; }
        public int? inf_tutor { get; set; }
        public int? inf_terapeuta { get; set; }
        public int? inf_coterapeuta { get; set; }

        public string inf_especifique { get; set; }
        public string inf_contacto_eme { get; set; }
        public string inf_telefono_eme { get; set; }
        public string inf_contacto_eme2 { get; set; }
        public string inf_telefono_eme2 { get; set; }
        public string inf_contacto_eme3 { get; set; }
        public string inf_telefono_eme3 { get; set; }

        public int inf_orientacion { get; set; }
        public string inf_especifique_or { get; set; }
        public string inf_pareja { get; set; }
        public int inf_religion { get; set; }
        public string inf_especifique_reg { get; set; }
        public string inf_trabaja { get; set; }
        public string inf_lugar_trabajo { get; set; }
        public string inf_horas_semana { get; set; }
        public string inf_vive_con { get; set; }

        public string inf_idea_su { get; set; }
        public string inf_idea_su_tiempo { get; set; }

        public string inf_intento_su { get; set; }
        public string inf_intento_su_tiempo { get; set; }
        public string inf_intento_su_metodo { get; set; }
        public string inf_intento_su_especifique { get; set; }

        public string inf_plan_su { get; set; }
        public string inf_plan_su_tiempo { get; set; }
        public string inf_plan_su_metodo { get; set; }
        public string inf_plan_su_especifique { get; set; }
        public string inf_plan_su_nivel { get; set; }

        public string inf_autolesion { get; set; }
        public string inf_autolesion_tiempo { get; set; }
        public string inf_autolesion_metodo { get; set; }
        public string inf_autolesion_especifique { get; set; }
        public string inf_autolesion_lugar { get; set; }
        public string inf_autolesion_lu_espe { get; set; }

        public string inf_llave_fam { get; set; }
        public int inf_paciente_id { get; set; }
    }
}
