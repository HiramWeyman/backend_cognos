using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class Pacientes
    {
        [Key]
        public int pac_id { get; set; }
        public string pac_paterno { get; set; }
        public string pac_materno { get; set; }
        public string pac_nombre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime pac_fecha_nacimiento { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime pac_fecha_ingreso { get; set; }

        public int pac_edad { get; set; }
        public int pac_genero { get; set; }
        public int pac_edocivil { get; set; }
        public int pac_escolaridad { get; set; }
        public string pac_ocupacion { get; set; }
        [Required]
        public string pac_email { get; set; }
        [Required]
        public string pac_telefono { get; set; }
        [Required]
        public string pac_domicilio{ get; set; }
        [Required]
        public int? pac_tutor { get; set; }
        


        [ForeignKey("Usuarios")]
        public int pac_usr_id { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
