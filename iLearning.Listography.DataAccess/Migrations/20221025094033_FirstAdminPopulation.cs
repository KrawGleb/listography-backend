using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class FirstAdminPopulation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b67ba75c-d9ca-4d5c-9248-f10e5e6c80b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5a7175e-c8cd-4e99-8918-6f977fc40e3b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "677FFB03-B872-4D82-96AF-08A2747699D6", "d6a58c5c-ee2b-42ef-9441-afc9695843d9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "A98F783C-2C85-46AB-BC7D-73F766D04DB3", "342a5bf6-48e1-4677-8f26-3deca039ed6f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SelectedLanguage", "SelectedTheme", "State", "TwoFactorEnabled", "UserName" },
                values: new object[] { "A3BF16BB-378C-4350-8BFF-FF1ED9CB2915", 0, "af7396d4-9b65-49a1-bc5e-7c8119dcadd2", "krawcevitsch@gmail.com", false, false, null, "KRAWCEVITSCH@GMAIL.COM", "CREATOR", "AQAAAAEAACcQAAAAENmR3VyO1iFAng5WjdT6ziiANQvfQFn4Qy7WHWJisPNljF6EUGibbRB9mTjpWJ2Y6A==", null, false, "6d0ec72f-b95a-4e4e-a6ad-153aed83d2db", null, null, 0, false, "Creator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "677FFB03-B872-4D82-96AF-08A2747699D6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A98F783C-2C85-46AB-BC7D-73F766D04DB3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "A3BF16BB-378C-4350-8BFF-FF1ED9CB2915");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b67ba75c-d9ca-4d5c-9248-f10e5e6c80b1", "c8b5072d-319e-4c26-aaea-287add654d67", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5a7175e-c8cd-4e99-8918-6f977fc40e3b", "c8123a67-5a2c-4e85-a42c-b67f417e466c", "Admin", "ADMIN" });
        }
    }
}
