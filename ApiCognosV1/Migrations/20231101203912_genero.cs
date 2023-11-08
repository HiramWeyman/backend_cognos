using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class genero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cat_terapeutas",
                columns: table => new
                {
                    tera_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tera_paterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tera_materno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tera_nombres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_terapeutas", x => x.tera_id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    gen_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gen_desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.gen_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cat_terapeutas");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
