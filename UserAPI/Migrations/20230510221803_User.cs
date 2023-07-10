using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAPI.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_User_AutorUsuarioId",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_User_AutorUsuarioId",
                table: "Noticias");

            migrationBuilder.RenameColumn(
                name: "AutorUsuarioId",
                table: "Noticias",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Noticias_AutorUsuarioId",
                table: "Noticias",
                newName: "IX_Noticias_UserId");

            migrationBuilder.RenameColumn(
                name: "AutorUsuarioId",
                table: "Aulas",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Aulas_AutorUsuarioId",
                table: "Aulas",
                newName: "IX_Aulas_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_User_UserId",
                table: "Aulas",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_User_UserId",
                table: "Noticias",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_User_UserId",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_User_UserId",
                table: "Noticias");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Noticias",
                newName: "AutorUsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Noticias_UserId",
                table: "Noticias",
                newName: "IX_Noticias_AutorUsuarioId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Aulas",
                newName: "AutorUsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Aulas_UserId",
                table: "Aulas",
                newName: "IX_Aulas_AutorUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_User_AutorUsuarioId",
                table: "Aulas",
                column: "AutorUsuarioId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_User_AutorUsuarioId",
                table: "Noticias",
                column: "AutorUsuarioId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
