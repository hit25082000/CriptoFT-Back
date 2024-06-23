using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace UserAPI.Migrations
{
    public partial class englishrefact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_User_userId",
                table: "UserProfile");

            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropColumn(
                name: "icone",
                table: "UserProfile");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "UserProfile",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "sobre",
                table: "UserProfile",
                newName: "Icon");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_userId",
                table: "UserProfile",
                newName: "IX_UserProfile_UserId");

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    VideoUrl = table.Column<string>(type: "longtext", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_UserProfile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ProfileId",
                table: "Videos",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_User_UserId",
                table: "UserProfile",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfile_User_UserId",
                table: "UserProfile");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserProfile",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "UserProfile",
                newName: "sobre");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfile_UserId",
                table: "UserProfile",
                newName: "IX_UserProfile_userId");

            migrationBuilder.AddColumn<string>(
                name: "icone",
                table: "UserProfile",
                type: "longtext",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Autor = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: true),
                    ProfileId = table.Column<int>(type: "int", nullable: true),
                    Titulo = table.Column<string>(type: "longtext", nullable: true),
                    VideoUrl = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aulas_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Aulas_UserProfile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    aspnetusersIDId = table.Column<int>(type: "int", nullable: true),
                    Autor = table.Column<int>(type: "int", nullable: false),
                    Conteudo = table.Column<string>(type: "longtext", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Titulo = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noticias_User_aspnetusersIDId",
                        column: x => x.aspnetusersIDId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_ProfileId",
                table: "Aulas",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_UserId",
                table: "Aulas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_aspnetusersIDId",
                table: "Noticias",
                column: "aspnetusersIDId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfile_User_userId",
                table: "UserProfile",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
