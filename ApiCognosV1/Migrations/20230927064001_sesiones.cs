using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class sesiones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sesion",
                columns: table => new
                {
                    sesion_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sesion_caso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sesion_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sesion_terapeuta = table.Column<int>(type: "int", nullable: false),
                    sesion_coterapeuta = table.Column<int>(type: "int", nullable: false),
                    sesion_objetivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sesion_rev_tarea = table.Column<int>(type: "int", nullable: false),
                    sesion_tecnica_abc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sesion_otras_tecnicas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sesion_tarea_asignada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sesion_notas_ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sesion_recomendacion_sup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sesion_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sesion_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sesion_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesion", x => x.sesion_id);
                    table.ForeignKey(
                        name: "FK_Sesion_Pacientes_sesion_paciente_id",
                        column: x => x.sesion_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sesion_sesion_paciente_id",
                table: "Sesion",
                column: "sesion_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sesion");
        }
    }
}
