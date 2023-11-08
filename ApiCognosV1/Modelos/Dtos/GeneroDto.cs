using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class GeneroDto
    {
        public int gen_id { get; set; }
        [Required]
        public string gen_desc { get; set; }
    }
}
