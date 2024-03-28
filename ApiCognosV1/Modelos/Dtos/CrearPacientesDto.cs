using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class CrearPacientesDto
    {

        [Required(ErrorMessage ="Apellido paterno es obligatorio")]
        public string pac_paterno { get; set; }
        public string pac_materno { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        public string pac_nombre { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime pac_fecha_nacimiento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime pac_fecha_ingreso { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        public int pac_edad { get; set; }
        public int pac_genero { get; set; }
        public int pac_edocivil { get; set; }

        public string pac_estructura_fam { get; set; }
        public int pac_escolaridad { get; set; }
        public string pac_ocupacion { get; set; }

        [Required(ErrorMessage = "Email es obligatorio")]
        public string pac_email { get; set; }

        [Required(ErrorMessage = "Teléfono  es obligatorio")]
        public string pac_telefono { get; set; }

        [Required(ErrorMessage = "El domicilio es obligatorio")]
        public string pac_domicilio { get; set; }

        [Required(ErrorMessage = "Tutor es obligatorio")]
        public int pac_tutor { get; set; }

        public int? pac_terapeuta { get; set; }
        public int? pac_coterapeuta { get; set; }
        public int? pac_comparte_usrid { get; set; }

        public string pac_especifique { get; set; }
        public string pac_contacto_eme { get; set; }
        public string pac_telefono_eme { get; set; }

        public string pac_contacto_eme2 { get; set; }
        public string pac_telefono_eme2 { get; set; }
        public string pac_contacto_eme3 { get; set; }
        public string pac_telefono_eme3 { get; set; }

        public int pac_orientacion { get; set; }
        public string pac_especifique_or { get; set; }
        public string pac_pareja { get; set; }
        public int pac_religion { get; set; }
        public string pac_especifique_reg { get; set; }
        public string pac_trabaja { get; set; }
        public string pac_lugar_trabajo { get; set; }
        public string pac_horas_semana { get; set; }
        public string pac_vive_con { get; set; }

        public string pac_idea_su { get; set; }
        public string pac_idea_su_tiempo { get; set; }

        public string pac_intento_su { get; set; }
        public string pac_intento_su_tiempo { get; set; }
        public string pac_intento_su_metodo { get; set; }
        public string pac_intento_su_especifique { get; set; }

        public string pac_plan_su { get; set; }
        public string pac_plan_su_tiempo { get; set; }
        public string pac_plan_su_metodo { get; set; }
        public string pac_plan_su_especifique { get; set; }
        public string pac_plan_su_nivel { get; set; }

        public string pac_autolesion { get; set; }
        public string pac_autolesion_tiempo { get; set; }
        public string pac_autolesion_metodo { get; set; }
        public string pac_autolesion_especifique { get; set; }
        public string pac_autolesion_lugar { get; set; }
        public string pac_autolesion_lu_espe { get; set; }

        public string pac_llave_fam { get; set; }


        [Required(ErrorMessage = "El usuario es obligatorio")]
        public int pac_usr_id { get; set; }

    }
}
