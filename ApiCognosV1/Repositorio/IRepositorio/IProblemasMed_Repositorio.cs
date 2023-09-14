using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IProblemasMed_Repositorio
    {
        ICollection<ProblemasMed> GetProblemasMed(int id);
        ProblemasMed GetProblemasMedUp(int id);
        bool CrearProblema(ProblemasMed prob);
        bool ActualizarProblemas(ProblemasMed prob);
        bool BorrarProblema(ProblemasMed prob);
        bool Guardar();
    }
}
