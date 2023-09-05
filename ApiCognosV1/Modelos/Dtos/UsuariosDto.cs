using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class UsuariosDto
    {
        [Key]
        public int usr_id { get; set; }
        public string usr_paterno { get; set; }
        public string usr_materno { get; set; }
        public string usr_nombre { get; set; }
        [Required]
        public string usr_email { get; set; }
        [Required]
        public string usr_password { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime usr_fecha_creacion { get; set; }

        public int usr_per_id { get; set; }
    
    }
}
