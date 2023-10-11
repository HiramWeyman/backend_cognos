using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class form_caso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormCaso",
                columns: table => new
                {
                    form_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    form_titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    form_hipotesis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    form_contraste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    form_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    form_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    form_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormCaso", x => x.form_id);
                    table.ForeignKey(
                        name: "FK_FormCaso_Pacientes_form_paciente_id",
                        column: x => x.form_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormCaso_form_paciente_id",
                table: "FormCaso",
                column: "form_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormCaso");
        }
    }
}
