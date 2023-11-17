using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ApiCognosV1.Modelos
{
    public class Files
    {
        [Key]
        public int DocumentId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string FileType { get; set; }
        [MaxLength]
        public byte[] DataFiles { get; set; }
        public DateTime? CreatedOn { get; set; }

        public int files_tipo_prueba { get; set; }

        [ForeignKey("Pacientes")]
        public int files_paciente_id { get; set; }
        public Pacientes Pacientes { get; set; }
    }
}
