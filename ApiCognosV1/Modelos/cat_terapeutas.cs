using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class cat_terapeutas
    {
        [Key]
        public int tera_id { get; set; }
        public string tera_paterno { get; set; }
        public string tera_materno { get; set; }
        public string tera_nombres { get; set; }

    
    }
}
