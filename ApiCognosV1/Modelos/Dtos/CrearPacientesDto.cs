﻿using System.ComponentModel.DataAnnotations.Schema;
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


        [Required(ErrorMessage = "El usuario es obligatorio")]
        public int pac_usr_id { get; set; }

    }
}
