using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class saludfisicamental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaludFM",
                columns: table => new
                {
                    salud_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salud_sueno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salud_sueno_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salud_alimentacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salud_alimentacion_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salud_act_fisica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salud_act_fisica_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salud_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salud_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salud_paciente_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaludFM", x => x.salud_id);
                    table.ForeignKey(
                        name: "FK_SaludFM_Pacientes_salud_paciente_id",
                        column: x => x.salud_paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "pac_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaludFM_salud_paciente_id",
                table: "SaludFM",
                column: "salud_paciente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaludFM");
        }
    }
}
