using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class EstructuraFamDto
    {
      
        public int fam_id { get; set; }

        public string fam_nombre { get; set; }

        public string fam_edad { get; set; }

        public string fam_parentesco { get; set; }

        public string fam_ocupacion { get; set; }

        public string fam_dependientes { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime fam_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime fam_fecha_modificacion { get; set; }

        public string fam_llave_pac { get; set; }

    }
}
