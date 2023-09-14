using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class antecedentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsumoSust",
                columns: table => new
                {
                    consumo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    consumo_sustancia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consumo_sino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consumo_edad_inicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consumo_cantidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consumo_tiempo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consumo_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    consumo_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    consumo_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumoSust", x => x.consumo_id);
                    table.ForeignKey(
                        name: "FK_ConsumoSust_Pacientes_consumo_paciente_id",
                        column: x => x.consumo_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrevioSalud",
                columns: table => new
                {
                    previo_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    previo_problema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    previo_medico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    previo_medicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    previo_tiempo_tratamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    previo_tiempo_psicologico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    previo_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    previo_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    previo_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrevioSalud", x => x.previo_id);
                    table.ForeignKey(
                        name: "FK_PrevioSalud_Pacientes_previo_paciente_id",
                        column: x => x.previo_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProblemasMed",
                columns: table => new
                {
                    problema_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    problema_problema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problema_medico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problema_medicamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problema_fecha_ini_trata = table.Column<DateTime>(type: "datetime2", nullable: false),
                    problema_tiempo_tratamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    problema_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    problema_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    problema_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemasMed", x => x.problema_id);
                    table.ForeignKey(
                        name: "FK_ProblemasMed_Pacientes_problema_paciente_id",
                        column: x => x.problema_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumoSust_consumo_paciente_id",
                table: "ConsumoSust",
                column: "consumo_paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_PrevioSalud_previo_paciente_id",
                table: "PrevioSalud",
                column: "previo_paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemasMed_problema_paciente_id",
                table: "ProblemasMed",
                column: "problema_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumoSust");

            migrationBuilder.DropTable(
                name: "PrevioSalud");

            migrationBuilder.DropTable(
                name: "ProblemasMed");
        }
    }
}
