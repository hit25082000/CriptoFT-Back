using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace UserAPI.Migrations
{
    public partial class string_FormFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_User_UserId",
                table: "Noticias");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Noticias",
                newName: "aspnetusersIDId");

            migrationBuilder.RenameIndex(
                name: "IX_Noticias_UserId",
                table: "Noticias",
                newName: "IX_Noticias_aspnetusersIDId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Noticias",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Aulas",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Aulas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(type: "int", nullable: true),
                    icone = table.Column<string>(type: "longtext", nullable: true),
                    sobre = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfile_User_userId",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_ProfileId",
                table: "Aulas",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_userId",
                table: "UserProfile",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_UserProfile_ProfileId",
                table: "Aulas",
                column: "ProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_User_aspnetusersIDId",
                table: "Noticias",
                column: "aspnetusersIDId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_UserProfile_ProfileId",
                table: "Aulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_User_aspnetusersIDId",
                table: "Noticias");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropIndex(
                name: "IX_Aulas_ProfileId",
                table: "Aulas");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Aulas");

            migrationBuilder.RenameColumn(
                name: "aspnetusersIDId",
                table: "Noticias",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Noticias_aspnetusersIDId",
                table: "Noticias",
                newName: "IX_Noticias_UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Noticias",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Aulas",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_User_UserId",
                table: "Noticias",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
