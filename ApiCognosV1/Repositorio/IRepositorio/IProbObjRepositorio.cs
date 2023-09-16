using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IProbObjRepositorio
    {
        ICollection<ProbObj> GetProbObj(int id);
        ProbObj GetProbObjUp(int id);
        bool CrearProbObj(ProbObj po);
        bool ActualizarProbObj(ProbObj po);
        bool BorrarProbObj(ProbObj po);
        bool Guardar();
    }
}
