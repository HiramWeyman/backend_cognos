using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class TestSCID
    {
        [Key]
        public int scid_id { get; set; }
        public string scid_desc { get; set; }
    }
}
