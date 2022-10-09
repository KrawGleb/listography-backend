using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class AddItemTemplateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Lists_Items_ItemTemplateId",
                table: "Lists",
                column: "ItemTemplateId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Items_ItemTemplateId",
                table: "Lists");

            migrationBuilder.DropIndex(
                name: "IX_Lists_ItemTemplateId",
                table: "Lists");

            migrationBuilder.DropColumn(
                name: "ItemTemplateId",
                table: "Lists");
            }
    }
}
