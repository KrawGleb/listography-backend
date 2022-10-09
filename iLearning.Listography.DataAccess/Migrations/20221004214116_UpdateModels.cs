using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Lists_UserListId",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "UserListId",
                table: "Tags",
                newName: "ListItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_UserListId",
                table: "Tags",
                newName: "IX_Tags_ListItemId");

            migrationBuilder.AddColumn<string>(
                name: "TextValue",
                table: "CustomFields",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Items_ListItemId",
                table: "Tags",
                column: "ListItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Items_ListItemId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TextValue",
                table: "CustomFields");

            migrationBuilder.RenameColumn(
                name: "ListItemId",
                table: "Tags",
                newName: "UserListId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_ListItemId",
                table: "Tags",
                newName: "IX_Tags_UserListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Lists_UserListId",
                table: "Tags",
                column: "UserListId",
                principalTable: "Lists",
                principalColumn: "Id");
        }
    }
}
