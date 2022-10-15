using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class ConfigureItemTemplateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_Lists_ItemTemplates_ItemTemplateId",
                table: "Lists");

            migrationBuilder.DropIndex(
                name: "IX_Lists_ItemTemplateId",
                table: "Lists");

            migrationBuilder.DropColumn(
                name: "ItemTemplateId",
                table: "Lists");

            migrationBuilder.AddColumn<int>(
                name: "UserListId",
                table: "ItemTemplates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemTemplates_UserListId",
                table: "ItemTemplates",
                column: "UserListId",
                unique: true,
                filter: "[UserListId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields",
                column: "ListItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTemplates_Lists_UserListId",
                table: "ItemTemplates",
                column: "UserListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTemplates_Lists_UserListId",
                table: "ItemTemplates");

            migrationBuilder.DropIndex(
                name: "IX_ItemTemplates_UserListId",
                table: "ItemTemplates");

            migrationBuilder.DropColumn(
                name: "UserListId",
                table: "ItemTemplates");

            migrationBuilder.AddColumn<int>(
                name: "ItemTemplateId",
                table: "Lists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lists_ItemTemplateId",
                table: "Lists",
                column: "ItemTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields",
                column: "ListItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_ItemTemplates_ItemTemplateId",
                table: "Lists",
                column: "ItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id");
        }
    }
}
