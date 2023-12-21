using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class TestIsraM
    {
        [Key]
        public int isra_m_id { get; set; }
        public string isra_m_desc { get; set; }
    }
}
