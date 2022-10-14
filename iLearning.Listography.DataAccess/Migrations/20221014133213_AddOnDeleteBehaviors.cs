using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class AddOnDeleteBehaviors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Items_ListItemId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Items_ListItemId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "ListItemId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ListItemTemplateId",
                table: "CustomFields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ListItemId",
                table: "CustomFields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Items_ListItemId",
                table: "CustomFields",
                column: "ListItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields",
                column: "ListItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Items_ListItemId",
                table: "Tags",
                column: "ListItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_Items_ListItemId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Items_ListItemId",
                table: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "ListItemId",
                table: "Tags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ListItemTemplateId",
                table: "CustomFields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ListItemId",
                table: "CustomFields",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_Items_ListItemId",
                table: "CustomFields",
                column: "ListItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields",
                column: "ListItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Items_ListItemId",
                table: "Tags",
                column: "ListItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
