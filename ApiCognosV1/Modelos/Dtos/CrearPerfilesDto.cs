using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class CrearPerfilesDto
    {
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string per_desc { get; set; }
    }
}
