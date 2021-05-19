using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodify.Infrastructures.Migrations
{
    public partial class AddCreateDateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateData",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateData",
                table: "ProductCategories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateData",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreateData",
                table: "ProductCategories");
        }
    }
}
