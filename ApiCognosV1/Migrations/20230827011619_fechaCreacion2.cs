using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class fechaCreacion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Usuarios",
                newName: "usr_fecha_creacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "usr_fecha_creacion",
                table: "Usuarios",
                newName: "FechaCreacion");
        }
    }
}
