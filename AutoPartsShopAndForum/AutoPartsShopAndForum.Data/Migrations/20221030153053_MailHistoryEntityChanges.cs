using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartsShopAndForum.Data.Migrations
{
    public partial class MailHistoryEntityChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "MailsHistories");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "MailsHistories");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "MailsHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "MailsHistories",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "MailsHistories");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "MailsHistories");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "MailsHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "MailsHistories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
