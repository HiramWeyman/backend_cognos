using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class Edocivil
    {
        [Key]
        public int civil_id { get; set; }
        [Required]
        public string civil_desc { get; set; }
    }
}
