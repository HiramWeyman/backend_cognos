using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class informe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Informe",
                columns: table => new
                {
                    inf_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inf_paterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inf_materno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inf_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inf_fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    inf_fecha_ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    inf_ultimo_mov = table.Column<DateTime>(type: "datetime2", nullable: false),
                    inf_edad = table.Column<int>(type: "int", nullable: false),
                    inf_genero = table.Column<int>(type: "int", nullable: false),
                    inf_edocivil = table.Column<int>(type: "int", nullable: false),
                    inf_escolaridad = table.Column<int>(type: "int", nullable: false),
                    inf_ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    inf_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inf_telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inf_domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inf_tutor = table.Column<int>(type: "int", nullable: false),
                    inf_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informe", x => x.inf_id);
                    table.ForeignKey(
                        name: "FK_Informe_Pacientes_inf_paciente_id",
                        column: x => x.inf_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Informe_inf_paciente_id",
                table: "Informe",
                column: "inf_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Informe");
        }
    }
}
