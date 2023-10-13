using ApiCognosV1.Data;
using ApiCognosV1.Modelos;
using ApiCognosV1.Repositorio.IRepositorio;

namespace ApiCognosV1.Repositorio
{
    public class ComentariosRepositorio:IComentariosRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public ComentariosRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarComentarios(Comentarios com)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            com.com_fecha_captura = enteredDate;
            _bd.Comentarios.Update(com);
            return Guardar();
        }

        public bool BorrarComentarios(Comentarios com)
        {
            _bd.Comentarios.Remove(com);
            return Guardar();
        }

        public bool CrearComentarios(Comentarios com)
        {
            var dateString2 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime enteredDate = DateTime.Parse(dateString2);
            com.com_fecha_captura = enteredDate;
            _bd.Comentarios.Add(com);
            return Guardar();
        }

        public ICollection<Comentarios> GetComentarios(int idx, int id_paciente)
        {
            return _bd.Comentarios.Where(p => p.com_index == idx && p.com_paciente_id== id_paciente).OrderBy(p => p.com_fecha_captura).ToList();
        }

        public Comentarios GetComentariosUp(int id)
        {
            return _bd.Comentarios.FirstOrDefault(p => p.com_id == id);
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
