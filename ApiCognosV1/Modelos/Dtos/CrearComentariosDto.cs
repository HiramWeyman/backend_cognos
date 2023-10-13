using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class CrearComentariosDto
    {
        public int com_usuario_id { get; set; }
        public int com_index { get; set; }
        public string com_nombre_usuario { get; set; }
        public string com_comentario { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime com_fecha_captura { get; set; }

        public int com_paciente_id { get; set; }
    }
}
