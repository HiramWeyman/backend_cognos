using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface ICreenciasRepositorio
    {
        Creencias GetCreencias(int id);
        bool CrearCreencias(Creencias creencia);
        bool ActualizarCreencias(Creencias creencia);
        bool Guardar();
    }
}
