using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class AddNewTemplateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_SelectOptions_CustomFields_CustomFieldId",
                table: "SelectOptions");

            migrationBuilder.DropIndex(
                name: "IX_SelectOptions_CustomFieldId",
                table: "SelectOptions");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.DropColumn(
                name: "CustomFieldId",
                table: "SelectOptions");

            migrationBuilder.DropColumn(
                name: "ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.AddColumn<int>(
                name: "CustomFieldTemplateId",
                table: "SelectOptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomFieldTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ListItemTemplateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomFieldTemplates_ItemTemplates_ListItemTemplateId",
                        column: x => x.ListItemTemplateId,
                        principalTable: "ItemTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectOptions_CustomFieldTemplateId",
                table: "SelectOptions",
                column: "CustomFieldTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldTemplates_ListItemTemplateId",
                table: "CustomFieldTemplates",
                column: "ListItemTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectOptions_CustomFieldTemplates_CustomFieldTemplateId",
                table: "SelectOptions",
                column: "CustomFieldTemplateId",
                principalTable: "CustomFieldTemplates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelectOptions_CustomFieldTemplates_CustomFieldTemplateId",
                table: "SelectOptions");

            migrationBuilder.DropTable(
                name: "CustomFieldTemplates");

            migrationBuilder.DropIndex(
                name: "IX_SelectOptions_CustomFieldTemplateId",
                table: "SelectOptions");

            migrationBuilder.DropColumn(
                name: "CustomFieldTemplateId",
                table: "SelectOptions");

            migrationBuilder.AddColumn<int>(
                name: "CustomFieldId",
                table: "SelectOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListItemTemplateId",
                table: "CustomFields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SelectOptions_CustomFieldId",
                table: "SelectOptions",
                column: "CustomFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFields_ListItemTemplateId",
                table: "CustomFields",
                column: "ListItemTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields",
                column: "ListItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SelectOptions_CustomFields_CustomFieldId",
                table: "SelectOptions",
                column: "CustomFieldId",
                principalTable: "CustomFields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
