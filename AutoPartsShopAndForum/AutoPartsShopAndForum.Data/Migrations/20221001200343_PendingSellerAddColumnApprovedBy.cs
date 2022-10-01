using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartsShopAndForum.Data.Migrations
{
    public partial class PendingSellerAddColumnApprovedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedById",
                table: "PendingSellers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PendingSellers_ApprovedById",
                table: "PendingSellers",
                column: "ApprovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_PendingSellers_AspNetUsers_ApprovedById",
                table: "PendingSellers",
                column: "ApprovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PendingSellers_AspNetUsers_ApprovedById",
                table: "PendingSellers");

            migrationBuilder.DropIndex(
                name: "IX_PendingSellers_ApprovedById",
                table: "PendingSellers");

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                table: "PendingSellers");
        }
    }
}
