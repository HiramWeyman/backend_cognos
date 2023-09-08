using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IOtrasAR_Repositorio
    {
        OtrasAR GetOtras(int id);
        bool CrearOtras(OtrasAR otras);
        bool ActualizarOtras(OtrasAR otras);
        bool Guardar();
    }
}
