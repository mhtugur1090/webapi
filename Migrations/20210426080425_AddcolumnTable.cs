using Microsoft.EntityFrameworkCore.Migrations;

namespace SahinKereste.Migrations
{
    public partial class AddcolumnTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "length",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "thickness",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "width",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "length",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "thickness",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "usage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "width",
                table: "Products");
        }
    }
}
