using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class UsuariosRegistroDto
    {
        [Required(ErrorMessage ="Apellido paterno es obligatorio")]
        public string usr_paterno { get; set; }
        public string usr_materno { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        public string usr_nombre { get; set; }
        [Required(ErrorMessage = "Email es obligatorio")]
        public string usr_email { get; set; }

        [Required(ErrorMessage = "Password es obligatorio")]
        public string usr_password { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime usr_fecha_creacion { get; set; }

        public int usr_per_id { get; set; }
    
    }
}
