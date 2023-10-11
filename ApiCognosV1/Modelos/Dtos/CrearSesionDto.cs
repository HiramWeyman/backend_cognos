
using System.ComponentModel.DataAnnotations;
namespace ApiCognosV1.Modelos.Dtos
{
    public class CrearSesionDto
    {
        public string sesion_caso { get; set; }
        public string sesion_no { get; set; }
        public int sesion_terapeuta { get; set; }
        public int sesion_coterapeuta { get; set; }
        public string sesion_objetivo { get; set; }
        public int sesion_rev_tarea { get; set; }
        public string sesion_tecnica_abc { get; set; }


        public string sesion_evento_act { get; set; }
        public string sesion_pensamientos_cre { get; set; }
        public string sesion_consecuencia_emo { get; set; }

        public string sesion_obj_emo { get; set; }
        public string sesion_obj_cond { get; set; }
        public string sesion_obj_prac { get; set; }

        public string sesion_preguntas_debate { get; set; }

        public string sesion_tecnicas_estrategias { get; set; }

        public string sesion_abc_tareas { get; set; }
        public string sesion_otras_tecnicas { get; set; }
        public string sesion_tarea_asignada { get; set; }
        public string sesion_notas_ad { get; set; }
        public string sesion_recomendacion_sup { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime sesion_fecha_captura { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy-MM-dd")]
        public DateTime sesion_fecha_modificacion { get; set; }

        public int sesion_paciente_id { get; set; }
    }
}
