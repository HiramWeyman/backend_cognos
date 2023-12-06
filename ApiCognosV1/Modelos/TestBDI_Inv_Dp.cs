using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class TestBDI_Inv_Dp
    {
        [Key]
        public int bdi_id { get; set; }
        public string bdi_desc { get; set; }
    }
}
