using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class bdidepresion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RespBDIdp",
                columns: table => new
                {
                    res_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    res_pregunta = table.Column<int>(type: "int", nullable: false),
                    res_respuesta = table.Column<int>(type: "int", nullable: false),
                    res_id_paciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespBDIdp", x => x.res_id);
                });

            migrationBuilder.CreateTable(
                name: "TestBDI_Inv_Dp",
                columns: table => new
                {
                    bdi_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bdi_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestBDI_Inv_Dp", x => x.bdi_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespBDIdp");

            migrationBuilder.DropTable(
                name: "TestBDI_Inv_Dp");
        }
    }
}
