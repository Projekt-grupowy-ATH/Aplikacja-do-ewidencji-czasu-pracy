using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendanceSystem.Migrations
{
    public partial class AddEmailtoTablePracownik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Pracownik",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Pracownik");
        }
    }
}
