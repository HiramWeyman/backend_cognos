using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos
{
    public class TablaPrueba
    {
        [Key]
        public int prueba_id { get; set; }
        public string prueba_descripcion { get; set; }
    }
}
