using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class SetUpM2MOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldSelectOption_CustomFields_CustomFieldsId",
                table: "CustomFieldSelectOption");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldSelectOption_SelectOptions_SelectOptionsId",
                table: "CustomFieldSelectOption");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldSelectOption_CustomFields_CustomFieldsId",
                table: "CustomFieldSelectOption",
                column: "CustomFieldsId",
                principalTable: "CustomFields",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldSelectOption_SelectOptions_SelectOptionsId",
                table: "CustomFieldSelectOption",
                column: "SelectOptionsId",
                principalTable: "SelectOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldSelectOption_CustomFields_CustomFieldsId",
                table: "CustomFieldSelectOption");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomFieldSelectOption_SelectOptions_SelectOptionsId",
                table: "CustomFieldSelectOption");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldSelectOption_CustomFields_CustomFieldsId",
                table: "CustomFieldSelectOption",
                column: "CustomFieldsId",
                principalTable: "CustomFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldSelectOption_SelectOptions_SelectOptionsId",
                table: "CustomFieldSelectOption",
                column: "SelectOptionsId",
                principalTable: "SelectOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
