using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class TestIsra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RespIsraC",
                columns: table => new
                {
                    res_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    res_pregunta = table.Column<int>(type: "int", nullable: false),
                    res_respuesta1 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta2 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta3 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta4 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta5 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta6 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta7 = table.Column<int>(type: "int", nullable: false),
                    res_observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    res_sum = table.Column<int>(type: "int", nullable: false),
                    res_id_paciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespIsraC", x => x.res_id);
                });

            migrationBuilder.CreateTable(
                name: "RespIsraF",
                columns: table => new
                {
                    res_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    res_pregunta = table.Column<int>(type: "int", nullable: false),
                    res_respuesta1 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta2 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta3 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta4 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta5 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta6 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta7 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta8 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta9 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta10 = table.Column<int>(type: "int", nullable: false),
                    res_observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    res_sum = table.Column<int>(type: "int", nullable: false),
                    res_id_paciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespIsraF", x => x.res_id);
                });

            migrationBuilder.CreateTable(
                name: "RespIsraM",
                columns: table => new
                {
                    res_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    res_pregunta = table.Column<int>(type: "int", nullable: false),
                    res_respuesta1 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta2 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta3 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta4 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta5 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta6 = table.Column<int>(type: "int", nullable: false),
                    res_respuesta7 = table.Column<int>(type: "int", nullable: false),
                    res_observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    res_sum = table.Column<int>(type: "int", nullable: false),
                    res_id_paciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespIsraM", x => x.res_id);
                });

            migrationBuilder.CreateTable(
                name: "TestIsraC",
                columns: table => new
                {
                    isra_c_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isra_c_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestIsraC", x => x.isra_c_id);
                });

            migrationBuilder.CreateTable(
                name: "TestIsraF",
                columns: table => new
                {
                    isra_f_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isra_f_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestIsraF", x => x.isra_f_id);
                });

            migrationBuilder.CreateTable(
                name: "TestIsraM",
                columns: table => new
                {
                    isra_m_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isra_m_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestIsraM", x => x.isra_m_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespIsraC");

            migrationBuilder.DropTable(
                name: "RespIsraF");

            migrationBuilder.DropTable(
                name: "RespIsraM");

            migrationBuilder.DropTable(
                name: "TestIsraC");

            migrationBuilder.DropTable(
                name: "TestIsraF");

            migrationBuilder.DropTable(
                name: "TestIsraM");
        }
    }
}
