using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class TestSCL
    {
        [Key]
        public int scl_id { get; set; }
        public string scl_desc { get; set; }
    }
}
