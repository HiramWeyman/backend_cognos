using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class agregar_campos_sesion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "sesion_abc_tareas",
                table: "Sesion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sesion_consecuencia_emo",
                table: "Sesion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sesion_evento_act",
                table: "Sesion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sesion_obj_cond",
                table: "Sesion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sesion_obj_emo",
                table: "Sesion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sesion_obj_prac",
                table: "Sesion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sesion_pensamientos_cre",
                table: "Sesion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sesion_preguntas_debate",
                table: "Sesion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sesion_tecnicas_estrategias",
                table: "Sesion",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sesion_abc_tareas",
                table: "Sesion");

            migrationBuilder.DropColumn(
                name: "sesion_consecuencia_emo",
                table: "Sesion");

            migrationBuilder.DropColumn(
                name: "sesion_evento_act",
                table: "Sesion");

            migrationBuilder.DropColumn(
                name: "sesion_obj_cond",
                table: "Sesion");

            migrationBuilder.DropColumn(
                name: "sesion_obj_emo",
                table: "Sesion");

            migrationBuilder.DropColumn(
                name: "sesion_obj_prac",
                table: "Sesion");

            migrationBuilder.DropColumn(
                name: "sesion_pensamientos_cre",
                table: "Sesion");

            migrationBuilder.DropColumn(
                name: "sesion_preguntas_debate",
                table: "Sesion");

            migrationBuilder.DropColumn(
                name: "sesion_tecnicas_estrategias",
                table: "Sesion");
        }
    }
}
