using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IConsumoSust_Repositorio
    {
        ICollection<ConsumoSust> GetConsumoSust(int id);
        ConsumoSust GetConsumoSustUp(int id);
        bool CrearConsumo(ConsumoSust con);
        bool ActualizarConsumo(ConsumoSust con);
        bool BorrarConsumo(ConsumoSust con);
        bool Guardar();
    }
}
