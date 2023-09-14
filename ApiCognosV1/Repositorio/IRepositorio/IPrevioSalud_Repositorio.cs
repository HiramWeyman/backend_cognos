using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IPrevioSalud_Repositorio
    {
        ICollection<PrevioSalud> GetPrevioSalud(int id);
        PrevioSalud GetPrevioSaludUp(int id);
        bool CrearPrevio(PrevioSalud pre);
        bool ActualizarPrevio(PrevioSalud pre);
        bool BorrarPrevio(PrevioSalud pre);
        bool Guardar();
    }
}
