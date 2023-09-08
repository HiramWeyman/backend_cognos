using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class evootrasdiagnostico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiagnosticoDS",
                columns: table => new
                {
                    diag_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diag_titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diag_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    diag_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    diag_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    diag_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticoDS", x => x.diag_id);
                    table.ForeignKey(
                        name: "FK_DiagnosticoDS_Pacientes_diag_paciente_id",
                        column: x => x.diag_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvolucionPR",
                columns: table => new
                {
                    evo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evo_titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evo_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    evo_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    evo_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    evo_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvolucionPR", x => x.evo_id);
                    table.ForeignKey(
                        name: "FK_EvolucionPR_Pacientes_evo_paciente_id",
                        column: x => x.evo_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtrasAR",
                columns: table => new
                {
                    otras_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    otras_titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    otras_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    otras_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    otras_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    otras_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtrasAR", x => x.otras_id);
                    table.ForeignKey(
                        name: "FK_OtrasAR_Pacientes_otras_paciente_id",
                        column: x => x.otras_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticoDS_diag_paciente_id",
                table: "DiagnosticoDS",
                column: "diag_paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_EvolucionPR_evo_paciente_id",
                table: "EvolucionPR",
                column: "evo_paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_OtrasAR_otras_paciente_id",
                table: "OtrasAR",
                column: "otras_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosticoDS");

            migrationBuilder.DropTable(
                name: "EvolucionPR");

            migrationBuilder.DropTable(
                name: "OtrasAR");
        }
    }
}
