using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class analisisFu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnalisisFU",
                columns: table => new
                {
                    analisis_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    analisis_ant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    analisis_ant_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    analisis_con = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    analisis_con_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    analisis_cons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    analisis_cons_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    analisis_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    analisis_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    analisis_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalisisFU", x => x.analisis_id);
                    table.ForeignKey(
                        name: "FK_AnalisisFU_Pacientes_analisis_paciente_id",
                        column: x => x.analisis_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalisisFU_analisis_paciente_id",
                table: "AnalisisFU",
                column: "analisis_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalisisFU");
        }
    }
}
