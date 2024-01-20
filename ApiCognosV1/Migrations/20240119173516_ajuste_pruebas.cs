using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class ajuste_pruebas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "res_id_maestro",
                table: "RespSCL",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "res_id_maestro",
                table: "RespSCID",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "res_id_maestro",
                table: "RespIsraM",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "res_id_maestro",
                table: "RespIsraF",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "res_id_maestro",
                table: "RespIsraC",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "res_id_maestro",
                table: "RespEllis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "res_id_maestro",
                table: "RespBDIdp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "res_id_maestro",
                table: "RespBAIan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Maestro_pruebas",
                columns: table => new
                {
                    maestro_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    maestro_fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    maestro_tipo_prueba = table.Column<int>(type: "int", nullable: false),
                    maestro_id_paciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestro_pruebas", x => x.maestro_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maestro_pruebas");

            migrationBuilder.DropColumn(
                name: "res_id_maestro",
                table: "RespSCL");

            migrationBuilder.DropColumn(
                name: "res_id_maestro",
                table: "RespSCID");

            migrationBuilder.DropColumn(
                name: "res_id_maestro",
                table: "RespIsraM");

            migrationBuilder.DropColumn(
                name: "res_id_maestro",
                table: "RespIsraF");

            migrationBuilder.DropColumn(
                name: "res_id_maestro",
                table: "RespIsraC");

            migrationBuilder.DropColumn(
                name: "res_id_maestro",
                table: "RespEllis");

            migrationBuilder.DropColumn(
                name: "res_id_maestro",
                table: "RespBDIdp");

            migrationBuilder.DropColumn(
                name: "res_id_maestro",
                table: "RespBAIan");
        }
    }
}
