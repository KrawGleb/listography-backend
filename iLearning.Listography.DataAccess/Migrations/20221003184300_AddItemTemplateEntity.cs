using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class AddItemTemplateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Lists_UserListId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Lists_Items_ItemTemplateId",
                table: "Lists");

            migrationBuilder.AlterColumn<int>(
                name: "UserListId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListItemTemplateId",
                table: "CustomFields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTemplates", x => x.Id);
                });

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
                name: "FK_Items_Lists_UserListId",
                table: "Items",
                column: "UserListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_ItemTemplates_ItemTemplateId",
                table: "Lists",
                column: "ItemTemplateId",
                principalTable: "ItemTemplates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomFields_ItemTemplates_ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Lists_UserListId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Lists_ItemTemplates_ItemTemplateId",
                table: "Lists");

            migrationBuilder.DropTable(
                name: "ItemTemplates");

            migrationBuilder.DropIndex(
                name: "IX_CustomFields_ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc7e5a6b-f69d-48c8-b712-c56844bb7799");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1d901d5-0fdd-4c08-8101-ad2e3113e982");

            migrationBuilder.DropColumn(
                name: "ListItemTemplateId",
                table: "CustomFields");

            migrationBuilder.AlterColumn<int>(
                name: "UserListId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24320eae-4911-4556-858c-5b07b5856dad", "3884a114-f6b1-4202-8205-3ced683d18d1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76a0d376-99ae-4f3a-b224-fbe947b36da7", "481842ee-7009-4645-b183-a7d648a49e45", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Lists_UserListId",
                table: "Items",
                column: "UserListId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_Items_ItemTemplateId",
                table: "Lists",
                column: "ItemTemplateId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
