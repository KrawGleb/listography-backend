using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class Renaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AccountId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_AccountId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Lists_AspNetUsers_AccountId",
                table: "Lists");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Lists",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Lists_AccountId",
                table: "Lists",
                newName: "IX_Lists_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Likes",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_AccountId",
                table: "Likes",
                newName: "IX_Likes_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Comments",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AccountId",
                table: "Comments",
                newName: "IX_Comments_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_ApplicationUserId",
                table: "Likes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_AspNetUsers_ApplicationUserId",
                table: "Lists",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_ApplicationUserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Lists_AspNetUsers_ApplicationUserId",
                table: "Lists");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Lists",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Lists_ApplicationUserId",
                table: "Lists",
                newName: "IX_Lists_AccountId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Likes",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_ApplicationUserId",
                table: "Likes",
                newName: "IX_Likes_AccountId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Comments",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments",
                newName: "IX_Comments_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AccountId",
                table: "Comments",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_AccountId",
                table: "Likes",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_AspNetUsers_AccountId",
                table: "Lists",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
