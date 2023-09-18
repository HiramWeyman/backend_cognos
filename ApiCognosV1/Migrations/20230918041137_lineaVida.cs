using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class lineaVida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LineaVida",
                columns: table => new
                {
                    lin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lin_titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lin_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lin_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lin_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lin_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaVida", x => x.lin_id);
                    table.ForeignKey(
                        name: "FK_LineaVida_Pacientes_lin_paciente_id",
                        column: x => x.lin_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineaVida_lin_paciente_id",
                table: "LineaVida",
                column: "lin_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineaVida");
        }
    }
}
