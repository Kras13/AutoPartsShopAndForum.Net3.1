using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartsShopAndForum.Data.Migrations
{
    public partial class MailHistoryBugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MailsHistories_AspNetUsers_FromUserId",
                table: "MailsHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_MailsHistories_AspNetUsers_ToId",
                table: "MailsHistories");

            migrationBuilder.DropIndex(
                name: "IX_MailsHistories_FromUserId",
                table: "MailsHistories");

            migrationBuilder.DropIndex(
                name: "IX_MailsHistories_ToId",
                table: "MailsHistories");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "MailsHistories");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "MailsHistories");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "MailsHistories");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverId",
                table: "MailsHistories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "MailsHistories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MailsHistories_ReceiverId",
                table: "MailsHistories",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_MailsHistories_SenderId",
                table: "MailsHistories",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MailsHistories_AspNetUsers_ReceiverId",
                table: "MailsHistories",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MailsHistories_AspNetUsers_SenderId",
                table: "MailsHistories",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MailsHistories_AspNetUsers_ReceiverId",
                table: "MailsHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_MailsHistories_AspNetUsers_SenderId",
                table: "MailsHistories");

            migrationBuilder.DropIndex(
                name: "IX_MailsHistories_ReceiverId",
                table: "MailsHistories");

            migrationBuilder.DropIndex(
                name: "IX_MailsHistories_SenderId",
                table: "MailsHistories");

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "MailsHistories");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "MailsHistories");

            migrationBuilder.AddColumn<string>(
                name: "FromId",
                table: "MailsHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FromUserId",
                table: "MailsHistories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToId",
                table: "MailsHistories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MailsHistories_FromUserId",
                table: "MailsHistories",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MailsHistories_ToId",
                table: "MailsHistories",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_MailsHistories_AspNetUsers_FromUserId",
                table: "MailsHistories",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MailsHistories_AspNetUsers_ToId",
                table: "MailsHistories",
                column: "ToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
