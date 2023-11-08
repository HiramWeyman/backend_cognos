using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class Genero
    {
        [Key]
        public int gen_id { get; set; }
        [Required]
        public string gen_desc { get; set; }
    }
}
