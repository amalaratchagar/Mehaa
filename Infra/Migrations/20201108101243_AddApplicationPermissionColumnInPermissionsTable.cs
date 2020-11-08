using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class AddApplicationPermissionColumnInPermissionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Permissions",
                table: "Permissions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "Permissions");
        }
    }
}
