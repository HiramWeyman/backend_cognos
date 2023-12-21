using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class RespIsraF
    {
        [Key]
        public int res_id { get; set; }
        public int res_pregunta { get; set; }
        public int res_respuesta1 { get; set; }
        public int res_respuesta2 { get; set; }
        public int res_respuesta3 { get; set; }
        public int res_respuesta4 { get; set; }
        public int res_respuesta5 { get; set; }
        public int res_respuesta6 { get; set; }
        public int res_respuesta7 { get; set; }
        public int res_respuesta8 { get; set; }
        public int res_respuesta9 { get; set; }
        public int res_respuesta10 { get; set; }
        public string res_observacion { get; set; }
        public int res_sum { get; set; }
        public int res_id_paciente { get; set; }
     
    }
}
