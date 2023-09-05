using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class Perfiles
    {
        [Key]
        public int per_id { get; set; }
        [Required]
        public string per_desc { get; set; }
    }
}
