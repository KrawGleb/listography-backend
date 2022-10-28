using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class SetDelBahaviorForSelectOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectOptions_CustomFieldTemplates_CustomFieldTemplateId",
                table: "SelectOptions");

            migrationBuilder.AlterColumn<int>(
                name: "CustomFieldTemplateId",
                table: "SelectOptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SelectOptions_CustomFieldTemplates_CustomFieldTemplateId",
                table: "SelectOptions",
                column: "CustomFieldTemplateId",
                principalTable: "CustomFieldTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectOptions_CustomFieldTemplates_CustomFieldTemplateId",
                table: "SelectOptions");

            migrationBuilder.AlterColumn<int>(
                name: "CustomFieldTemplateId",
                table: "SelectOptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectOptions_CustomFieldTemplates_CustomFieldTemplateId",
                table: "SelectOptions",
                column: "CustomFieldTemplateId",
                principalTable: "CustomFieldTemplates",
                principalColumn: "Id");
        }
    }
}
