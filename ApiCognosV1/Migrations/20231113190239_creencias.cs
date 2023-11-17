using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class creencias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creencias",
                columns: table => new
                {
                    creencia_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creencia_irra1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creencia_irra2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creencia_irra3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creencia_irra4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creencia_irra5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creencia_irra6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creencia_irra7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creencia_irra8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creencia_irra9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creencia_irra10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creencia_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    creencia_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    creencia_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creencias", x => x.creencia_id);
                    table.ForeignKey(
                        name: "FK_Creencias_Pacientes_creencia_paciente_id",
                        column: x => x.creencia_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Creencias_creencia_paciente_id",
                table: "Creencias",
                column: "creencia_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Creencias");
        }
    }
}
