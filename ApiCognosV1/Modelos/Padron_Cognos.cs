using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class Padron_Cognos
    {
        //string  dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
        //DateTime enteredDate = DateTime.Parse(dateString2);
        [Key]
        public int pad_id { get; set; }
        public string pad_nombre { get; set; }
        public string pad_correo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime pad_fecha_creacion { get; set; } = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

        [DefaultValue("A")]
        public string pad_estatus { get; set; }
    }
}
