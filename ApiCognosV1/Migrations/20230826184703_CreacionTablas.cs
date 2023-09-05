using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perfiles",
                columns: table => new
                {
                    per_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    per_desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfiles", x => x.per_id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usr_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usr_paterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usr_materno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usr_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usr_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usr_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usr_per_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usr_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perfiles");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
