using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using XAct;

namespace ApiCognosV1.Repositorio
{
    public class SesionRepositorio: ISesionRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public SesionRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarSesion(Sesion se)
        {

            var facSesion = se.sesion_fecha?.ToString("yyyy-MM-dd");
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            DateTime fechaCapturada = DateTime.Parse(facSesion);
            se.sesion_fecha_modificacion = enteredDate;
            se.sesion_fecha = fechaCapturada;
            _bd.Sesion.Update(se);
            return Guardar();
        }

        public bool BorrarSesion(Sesion se)
        {
            _bd.Sesion.Remove(se);
            return Guardar();
        }

        public bool CrearSesion(Sesion se)
        {
            var facSesion = se.sesion_fecha?.ToString("yyyy-MM-dd");
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            DateTime fechaCapturada = DateTime.Parse(facSesion);
            se.sesion_fecha_modificacion = enteredDate;
            se.sesion_fecha_captura = enteredDate;
            se.sesion_fecha = fechaCapturada;
            _bd.Sesion.Add(se);
            return Guardar();
        }

        public ICollection<Sesion> GetSesion(int id)
        {
            // int propertyName = "sesion_paciente_id";
            //int propertyValue = id;
            // IQueryable<Sesion> order = _bd.Sesion.FromSql($"SELECT * from iescogno_expediente.dbo.Sesion where sesion_paciente_id="+id+" order by CAST(sesion_no AS int)");
            // List<Sesion> sesiones = null;
            // sesiones = _bd.Database.SqlQueryRaw<Sesion>($"SELECT * from iescogno_expediente.dbo.Sesion where sesion_paciente_id=@id order by CAST(sesion_no AS int)", new SqlParameter("@id", id)).ToList();

            //return _bd.Sesion.Where(p => p.sesion_paciente_id == id).OrderBy(SqlFunctions.IsNumeric(p => p.sesion_no)).ToList();
            //return _bd.Sesion.Where(p => p.sesion_paciente_id == id).OrderBy(p => p.sesion_no.ToInt32()).ToList();
            try {
                //Produccion
               // var blogs = _bd.Sesion
               //.FromSql($"SELECT sesion_id, sesion_caso, sesion_no, sesion_terapeuta, sesion_coterapeuta, sesion_objetivo, sesion_rev_tarea, sesion_tecnica_abc, sesion_otras_tecnicas, sesion_tarea_asignada, sesion_notas_ad, sesion_recomendacion_sup, sesion_fecha_captura, sesion_fecha_modificacion, sesion_paciente_id, sesion_abc_tareas, sesion_consecuencia_emo, sesion_evento_act, sesion_obj_cond, sesion_obj_emo, sesion_obj_prac, sesion_pensamientos_cre, sesion_preguntas_debate, sesion_tecnicas_estrategias, sesion_impedimiento, sesion_fecha from iescogno_expediente.dbo.Sesion  WHERE sesion_paciente_id = {id} order by LEN(sesion_no)")
               //.ToList();
               // return blogs;

                //Test
                var blogs = _bd.Sesion
               .FromSql($"SELECT sesion_id, sesion_caso, sesion_no, sesion_terapeuta, sesion_coterapeuta, sesion_objetivo, sesion_rev_tarea, sesion_tecnica_abc, sesion_otras_tecnicas, sesion_tarea_asignada, sesion_notas_ad, sesion_recomendacion_sup, sesion_fecha_captura, sesion_fecha_modificacion, sesion_paciente_id, sesion_abc_tareas, sesion_consecuencia_emo, sesion_evento_act, sesion_obj_cond, sesion_obj_emo, sesion_obj_prac, sesion_pensamientos_cre, sesion_preguntas_debate, sesion_tecnicas_estrategias, sesion_impedimiento, sesion_fecha from Sesion  WHERE sesion_paciente_id = {id} ORDER BY CAST(sesion_no AS INT)")
               .ToList();
                return blogs;
            }
            catch (Exception e) {
                throw e.InnerException;
            }
        }

        public Sesion GetSesionUp(int id)
        {
            return _bd.Sesion.FirstOrDefault(p => p.sesion_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
