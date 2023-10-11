using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class otras_areas_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "otras_apoyo_s",
                table: "OtrasAR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "otras_aspectos_m",
                table: "OtrasAR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "otras_autocontrol",
                table: "OtrasAR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "otras_recursos_p",
                table: "OtrasAR",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "otras_situacion_v",
                table: "OtrasAR",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "otras_apoyo_s",
                table: "OtrasAR");

            migrationBuilder.DropColumn(
                name: "otras_aspectos_m",
                table: "OtrasAR");

            migrationBuilder.DropColumn(
                name: "otras_autocontrol",
                table: "OtrasAR");

            migrationBuilder.DropColumn(
                name: "otras_recursos_p",
                table: "OtrasAR");

            migrationBuilder.DropColumn(
                name: "otras_situacion_v",
                table: "OtrasAR");
        }
    }
}
