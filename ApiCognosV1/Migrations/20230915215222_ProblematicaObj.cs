using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class ProblematicaObj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProbObj",
                columns: table => new
                {
                    pro_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pro_problema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pro_objetivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pro_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pro_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pro_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProbObj", x => x.pro_id);
                    table.ForeignKey(
                        name: "FK_ProbObj_Pacientes_pro_paciente_id",
                        column: x => x.pro_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProbObj_pro_paciente_id",
                table: "ProbObj",
                column: "pro_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProbObj");
        }
    }
}
