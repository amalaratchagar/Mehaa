using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class AddedAdditionalColumnsinItemStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecentInwardQuantity",
                table: "ItemStocks");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ItemStocks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "ItemStocks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ItemStocks");

            migrationBuilder.DropColumn(
                name: "Discription",
                table: "ItemStocks");

            migrationBuilder.AddColumn<int>(
                name: "RecentInwardQuantity",
                table: "ItemStocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
