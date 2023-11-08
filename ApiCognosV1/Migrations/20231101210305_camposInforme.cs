using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class camposInforme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "inf_coterapeuta",
                table: "Informe",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "inf_terapeuta",
                table: "Informe",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inf_coterapeuta",
                table: "Informe");

            migrationBuilder.DropColumn(
                name: "inf_terapeuta",
                table: "Informe");
        }
    }
}
