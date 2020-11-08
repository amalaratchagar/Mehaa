using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class RenamingMobileColumnInUsersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modile",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Modile",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
