using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class AddLanguageAndThemeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedLanguage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedTheme",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedLanguage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SelectedTheme",
                table: "AspNetUsers");
        }
    }
}
