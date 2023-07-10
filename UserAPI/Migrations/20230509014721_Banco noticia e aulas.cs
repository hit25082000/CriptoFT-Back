using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace UserAPI.Migrations
{
    public partial class Banconoticiaeaulas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aulas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Titulo = table.Column<string>(type: "longtext", nullable: true),
                    Descricao = table.Column<string>(type: "longtext", nullable: true),
                    VideoUrl = table.Column<string>(type: "longtext", nullable: true),
                    Autor = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AutorUsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aulas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aulas_User_AutorUsuarioId",
                        column: x => x.AutorUsuarioId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Titulo = table.Column<string>(type: "longtext", nullable: true),
                    Conteudo = table.Column<string>(type: "longtext", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Autor = table.Column<int>(type: "int", nullable: false),
                    AutorUsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noticias_User_AutorUsuarioId",
                        column: x => x.AutorUsuarioId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_AutorUsuarioId",
                table: "Aulas",
                column: "AutorUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_AutorUsuarioId",
                table: "Noticias",
                column: "AutorUsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aulas");

            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
