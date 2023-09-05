using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class UsuariosLoginDto
    {
    
        [Required(ErrorMessage = "Email es obligatorio")]
        public string usr_email { get; set; }

        [Required(ErrorMessage = "Password es obligatorio")]
        public string usr_password { get; set; }
    
    }
}
