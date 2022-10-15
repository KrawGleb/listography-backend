using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class AddOnDeleteCascadeToAccountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_AspNetUsers_AccountId",
                table: "Lists");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_AspNetUsers_AccountId",
                table: "Lists",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_AspNetUsers_AccountId",
                table: "Lists");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_AspNetUsers_AccountId",
                table: "Lists",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
