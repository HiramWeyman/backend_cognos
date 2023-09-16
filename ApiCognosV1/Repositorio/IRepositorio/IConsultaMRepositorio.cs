using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IConsultaMRepositorio
    {
        ConsultaM GetConsulta(int id);
        bool CrearConsulta(ConsultaM cn);
        bool ActualizarConsulta(ConsultaM cn);
        bool Guardar();
    }
}
