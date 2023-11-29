using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class TestBAI_Inv_An
    {
        [Key]
        public int bai_id { get; set; }
        public string bai_desc { get; set; }
    }
}
