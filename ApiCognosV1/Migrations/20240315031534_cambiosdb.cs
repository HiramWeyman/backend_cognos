using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class cambiosdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TablaPrueba");

            migrationBuilder.AddColumn<DateTime>(
                name: "sesion_fecha",
                table: "Sesion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "pac_autolesion",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_autolesion_especifique",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_autolesion_lu_espe",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_autolesion_lugar",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_autolesion_metodo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_autolesion_tiempo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_contacto_eme2",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_contacto_eme3",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_especifique_or",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_especifique_reg",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_horas_semana",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_idea_su",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_idea_su_tiempo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_intento_su",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_intento_su_especifique",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_intento_su_metodo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_intento_su_tiempo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_llave_fam",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_lugar_trabajo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pac_orientacion",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "pac_pareja",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_plan_su",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_plan_su_especifique",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_plan_su_metodo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_plan_su_nivel",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_plan_su_tiempo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pac_religion",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "pac_telefono_eme2",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_telefono_eme3",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_trabaja",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pac_vive_con",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_autolesion",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_autolesion_especifique",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_autolesion_lu_espe",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_autolesion_lugar",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_autolesion_metodo",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_autolesion_tiempo",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_contacto_eme",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_contacto_eme2",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_contacto_eme3",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_especifique",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_especifique_or",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_especifique_reg",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_horas_semana",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_idea_su",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_idea_su_tiempo",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_intento_su",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_intento_su_especifique",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_intento_su_metodo",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_intento_su_tiempo",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_llave_fam",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_lugar_trabajo",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "inf_orientacion",
                table: "Informe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "inf_pareja",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_plan_su",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_plan_su_especifique",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_plan_su_metodo",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_plan_su_nivel",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_plan_su_tiempo",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "inf_religion",
                table: "Informe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "inf_telefono_eme",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_telefono_eme2",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_telefono_eme3",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_trabaja",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "inf_vive_con",
                table: "Informe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstructuraFami",
                columns: table => new
                {
                    fam_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fam_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fam_edad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fam_parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fam_ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fam_dependientes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fam_fecha_captura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fam_fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fam_llave_pac = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstructuraFami", x => x.fam_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstructuraFami");

            migrationBuilder.DropColumn(
                name: "sesion_fecha",
                table: "Sesion");

            migrationBuilder.DropColumn(
                name: "pac_autolesion",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_autolesion_especifique",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_autolesion_lu_espe",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_autolesion_lugar",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_autolesion_metodo",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_autolesion_tiempo",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_contacto_eme2",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_contacto_eme3",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_especifique_or",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_especifique_reg",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_horas_semana",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_idea_su",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_idea_su_tiempo",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_intento_su",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_intento_su_especifique",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_intento_su_metodo",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_intento_su_tiempo",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_llave_fam",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_lugar_trabajo",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_orientacion",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_pareja",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_plan_su",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_plan_su_especifique",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_plan_su_metodo",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_plan_su_nivel",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_plan_su_tiempo",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_religion",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_telefono_eme2",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_telefono_eme3",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_trabaja",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pac_vive_con",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "inf_autolesion",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_autolesion_especifique",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_autolesion_lu_espe",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_autolesion_lugar",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_autolesion_metodo",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_autolesion_tiempo",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_contacto_eme",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_contacto_eme2",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_contacto_eme3",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_especifique",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_especifique_or",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_especifique_reg",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_horas_semana",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_idea_su",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_idea_su_tiempo",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_intento_su",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_intento_su_especifique",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_intento_su_metodo",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_intento_su_tiempo",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_llave_fam",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_lugar_trabajo",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_orientacion",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_pareja",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_plan_su",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_plan_su_especifique",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_plan_su_metodo",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_plan_su_nivel",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_plan_su_tiempo",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_religion",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_telefono_eme",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_telefono_eme2",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_telefono_eme3",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_trabaja",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_vive_con",
                table: "Informe");

            migrationBuilder.CreateTable(
                name: "TablaPrueba",
                columns: table => new
                {
                    prueba_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prueba_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaPrueba", x => x.prueba_id);
                });
        }
    }
}
