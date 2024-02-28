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
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            se.sesion_fecha_modificacion = enteredDate;
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
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            se.sesion_fecha_modificacion = enteredDate;
            se.sesion_fecha_captura = enteredDate;
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
            var blogs = _bd.Sesion
           .FromSql($"SELECT * from iescogno_expediente.dbo.Sesion  WHERE sesion_paciente_id = {id} order by LEN(sesion_no)")
           .ToList();


            return blogs;
            //return _bd.Sesion.Where(p => p.sesion_paciente_id == id).OrderBy(SqlFunctions.IsNumeric(p => p.sesion_no)).ToList();
            //return _bd.Sesion.Where(p => p.sesion_paciente_id == id).OrderBy(p => p.sesion_no.ToInt32()).ToList();
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
