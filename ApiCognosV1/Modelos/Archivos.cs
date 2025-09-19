namespace ApiCognosV1.Modelos
{

    public class Archivo
    {
        public int ArchivoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ruta { get; set; } // relativa dentro de wwwroot
        public string ContentType { get; set; }
        public DateTime FechaSubida { get; set; }
        public bool Eliminado { get; set; }

        // 🔹 FK al catálogo
        public int CategoriaId { get; set; }
    }
}
