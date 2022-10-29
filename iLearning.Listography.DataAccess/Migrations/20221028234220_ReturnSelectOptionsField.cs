using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class ReturnSelectOptionsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomFieldId",
                table: "SelectOptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelectOptions_CustomFieldId",
                table: "SelectOptions",
                column: "CustomFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectOptions_CustomFields_CustomFieldId",
                table: "SelectOptions",
                column: "CustomFieldId",
                principalTable: "CustomFields",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectOptions_CustomFields_CustomFieldId",
                table: "SelectOptions");

            migrationBuilder.DropIndex(
                name: "IX_SelectOptions_CustomFieldId",
                table: "SelectOptions");

            migrationBuilder.DropColumn(
                name: "CustomFieldId",
                table: "SelectOptions");
        }
    }
}
