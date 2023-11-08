using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IEdocivilRepositorio
    {
        ICollection<Edocivil> GetEdocivil();
        Edocivil GetEdocivil(int id);
        bool ExisteEdocivil(string desc);
        bool ExisteEdocivil(int id);
        bool CrearEdocivil(Edocivil Edocivil);
        bool ActualizarEdocivil(Edocivil Edocivil);
        bool BorrarEdocivil(Edocivil Edocivil);
        bool Guardar();
    }
}
