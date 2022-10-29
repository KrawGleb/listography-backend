using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class ChangeListOnUserDelBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_AspNetUsers_ApplicationUserId",
                table: "Lists");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_AspNetUsers_ApplicationUserId",
                table: "Lists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_AspNetUsers_ApplicationUserId",
                table: "Lists");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_AspNetUsers_ApplicationUserId",
                table: "Lists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
