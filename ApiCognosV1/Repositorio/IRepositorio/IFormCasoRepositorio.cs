using ApiCognosV1.Modelos;

namespace ApiCognosV1.Repositorio.IRepositorio
{
    public interface IFormCasoRepositorio
    {
        FormCaso GetFormCaso(int id);

        bool CrearFormCaso(FormCaso frm);
        bool ActualizarFormCaso(FormCaso frm);
        //bool BorrarPaciente(Pacientes paciente);
        bool Guardar();
    }
}
