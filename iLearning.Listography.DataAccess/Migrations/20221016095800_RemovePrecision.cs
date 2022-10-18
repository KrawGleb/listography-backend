using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace iLearning.Listography.DataAccess.Migrations
{
    public partial class RemovePrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NumberValue",
                table: "CustomFields",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldPrecision: 2,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NumberValue",
                table: "CustomFields",
                type: "decimal(2,2)",
                precision: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
