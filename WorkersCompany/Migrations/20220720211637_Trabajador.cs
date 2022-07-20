using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkersCompany.Migrations
{
    public partial class Trabajador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Trabajador");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Trabajador",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Trabajador");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Trabajador",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
