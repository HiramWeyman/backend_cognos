using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class Tratamiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tratamiento",
                columns: table => new
                {
                    trata_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trata_objetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trata_tecnica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trata_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trata_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trata_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamiento", x => x.trata_id);
                    table.ForeignKey(
                        name: "FK_Tratamiento_Pacientes_trata_paciente_id",
                        column: x => x.trata_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tratamiento_trata_paciente_id",
                table: "Tratamiento",
                column: "trata_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tratamiento");
        }
    }
}
