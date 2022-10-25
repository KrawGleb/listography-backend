using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class SeedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "677FFB03-B872-4D82-96AF-08A2747699D6", "A3BF16BB-378C-4350-8BFF-FF1ED9CB2915" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "677FFB03-B872-4D82-96AF-08A2747699D6", "A3BF16BB-378C-4350-8BFF-FF1ED9CB2915" });
        }
    }
}
