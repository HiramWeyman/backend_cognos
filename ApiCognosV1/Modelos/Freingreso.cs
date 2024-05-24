using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace ApiCognosV1.Modelos
{
    public class Freingreso
    {
        [Key]
        public int Idrei { get; set; }
        public int Id_pac_rei { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime fecha_rei { get; set; }

        public string usuario_rei { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime fecha_creacion_rei { get; set; }
        

    }
}
