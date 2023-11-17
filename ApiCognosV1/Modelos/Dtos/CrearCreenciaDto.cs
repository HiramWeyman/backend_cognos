using System.ComponentModel.DataAnnotations;

namespace ApiCognosV1.Modelos.Dtos
{
    public class CrearCreenciaDto
    {
        public string creencia_irra1 { get; set; }
        public string creencia_irra2 { get; set; }
        public string creencia_irra3 { get; set; }
        public string creencia_irra4 { get; set; }
        public string creencia_irra5 { get; set; }
        public string creencia_irra6 { get; set; }
        public string creencia_irra7 { get; set; }
        public string creencia_irra8 { get; set; }
        public string creencia_irra9 { get; set; }
        public string creencia_irra10 { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime creencia_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime creencia_fecha_modificacion { get; set; }
        public int creencia_paciente_id { get; set; }
    }
}
