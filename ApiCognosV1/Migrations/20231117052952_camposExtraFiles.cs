using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class camposExtraFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "files_paciente_id",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "files_tipo_prueba",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Files_files_paciente_id",
                table: "Files",
                column: "files_paciente_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Pacientes_files_paciente_id",
                table: "Files",
                column: "files_paciente_id",
                principalTable: "Pacientes",
                principalColumn: "pac_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Pacientes_files_paciente_id",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_files_paciente_id",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "files_paciente_id",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "files_tipo_prueba",
                table: "Files");
        }
    }
}
