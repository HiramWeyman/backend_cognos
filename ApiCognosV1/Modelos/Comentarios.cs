using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCognosV1.Modelos
{
    public class Comentarios
    {
        [Key]
        public int com_id { get; set; }
        public int com_usuario_id { get; set; }
        public int com_index { get; set; }
        public string com_nombre_usuario { get; set; }
        public string com_comentario { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime com_fecha_captura { get; set; }

        [ForeignKey("Pacientes")]
        public int com_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }

    }
}
