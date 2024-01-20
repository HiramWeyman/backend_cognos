using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class RespBAIan
    {
        [Key]
        public int res_id { get; set; }
        public int res_pregunta { get; set; }
        public int res_respuesta { get; set; }
        public int res_id_paciente { get; set; }

        public int res_id_maestro { get; set; }

    }
}
