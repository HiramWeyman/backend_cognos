using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class comentarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    com_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    com_usuario_id = table.Column<int>(type: "int", nullable: false),
                    com_index = table.Column<int>(type: "int", nullable: false),
                    com_nombre_usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    com_comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    com_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    com_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.com_id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Pacientes_com_paciente_id",
                        column: x => x.com_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_com_paciente_id",
                table: "Comentarios",
                column: "com_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");
        }
    }
}
