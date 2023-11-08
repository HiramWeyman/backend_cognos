using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class Escolaridad
    {
        [Key]
        public int esc_id { get; set; }
        [Required]
        public string esc_desc { get; set; }
    }
}
