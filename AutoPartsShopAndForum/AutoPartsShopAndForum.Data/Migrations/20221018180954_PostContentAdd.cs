using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartsShopAndForum.Data.Migrations
{
    public partial class PostContentAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
