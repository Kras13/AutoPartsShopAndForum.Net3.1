using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartsShopAndForum.Data.Migrations
{
    public partial class ProductFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                type: "int",
                nullable: true);
        }
    }
}
