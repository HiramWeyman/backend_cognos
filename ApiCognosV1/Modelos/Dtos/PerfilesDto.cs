using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class PerfilesDto
    {
        public int per_id { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string per_desc { get; set; }
    }
}
