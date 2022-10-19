using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab.Migrations
{
    public partial class UpdateAgeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<uint>(
                name: "Age",
                table: "Employees",
                type: "int unsigned",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Age",
                table: "Employees",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(uint),
                oldType: "int unsigned");
        }
    }
}
