using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class TestEllis
    {
        [Key]
        public int ellis_id { get; set; }
        public string ellis_desc { get; set; }
        public string ellis_p { get; set; }
    }
}
