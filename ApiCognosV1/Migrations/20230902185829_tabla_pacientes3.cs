using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class tabla_pacientes3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    pac_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pac_paterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pac_materno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pac_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pac_fecha_nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pac_fecha_ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pac_edad = table.Column<int>(type: "int", nullable: false),
                    pac_genero = table.Column<int>(type: "int", nullable: false),
                    pac_edocivil = table.Column<int>(type: "int", nullable: false),
                    pac_escolaridad = table.Column<int>(type: "int", nullable: false),
                    pac_ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pac_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pac_telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pac_domicilio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pac_usr_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.pac_id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Usuarios_pac_usr_id",
                        column: x => x.pac_usr_id,
                        principalTable: "Usuarios",
                        principalColumn: "usr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_pac_usr_id",
                table: "Pacientes",
                column: "pac_usr_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
