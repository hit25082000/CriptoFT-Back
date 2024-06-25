using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAPI.Migrations
{
    public partial class article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "Articles",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Articles",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Articles",
                type: "longtext",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Articles");
        }
    }
}
