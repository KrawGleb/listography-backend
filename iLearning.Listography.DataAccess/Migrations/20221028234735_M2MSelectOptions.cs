using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class M2MSelectOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CustomFieldSelectOption",
                columns: table => new
                {
                    CustomFieldsId = table.Column<int>(type: "int", nullable: false),
                    SelectOptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldSelectOption", x => new { x.CustomFieldsId, x.SelectOptionsId });
                    table.ForeignKey(
                        name: "FK_CustomFieldSelectOption_CustomFields_CustomFieldsId",
                        column: x => x.CustomFieldsId,
                        principalTable: "CustomFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CustomFieldSelectOption_SelectOptions_SelectOptionsId",
                        column: x => x.SelectOptionsId,
                        principalTable: "SelectOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldSelectOption_SelectOptionsId",
                table: "CustomFieldSelectOption",
                column: "SelectOptionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomFieldSelectOption");

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
    }
}
