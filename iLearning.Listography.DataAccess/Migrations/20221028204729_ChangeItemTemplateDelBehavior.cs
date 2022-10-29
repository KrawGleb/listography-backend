using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class ChangeItemTemplateDelBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields",
                column: "ListItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields",
                column: "ListItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
