using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface ILineaVidaRepositorio
    {
            
        ICollection<LineaVida> GetLineaVida(int id);
        LineaVida GetLineaVidaUp(int id);
        bool CrearLineaVida(LineaVida tr);
        bool ActualizarLineaVida(LineaVida tr);
        bool BorrarLineaVida(LineaVida tr);
        bool Guardar();
    }
}
