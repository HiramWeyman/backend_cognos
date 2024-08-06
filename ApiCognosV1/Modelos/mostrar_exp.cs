using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class mostrar_exp
    {
        [Key]
        public int most_id { get; set; }
        public int most_id_maestro { get; set; }
        public int most_tipo_prueba { get; set; }
        public int most_expediente { get; set; }
        public int most_id_imagen { get; set; }
        
    }
}
