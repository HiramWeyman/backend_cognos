using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCognosV1.Migrations
{
    /// <inheritdoc />
    public partial class foreignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_usr_per_id",
                table: "Usuarios",
                column: "usr_per_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Perfiles_usr_per_id",
                table: "Usuarios",
                column: "usr_per_id",
                principalTable: "Perfiles",
                principalColumn: "per_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Perfiles_usr_per_id",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_usr_per_id",
                table: "Usuarios");
        }
    }
}
