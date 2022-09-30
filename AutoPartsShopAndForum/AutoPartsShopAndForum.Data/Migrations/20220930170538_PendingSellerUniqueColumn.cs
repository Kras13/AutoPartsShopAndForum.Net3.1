using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartsShopAndForum.Data.Migrations
{
    public partial class PendingSellerUniqueColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PendingSellers_UserId",
                table: "PendingSellers");

            migrationBuilder.CreateIndex(
                name: "IX_PendingSellers_UserId",
                table: "PendingSellers",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PendingSellers_UserId",
                table: "PendingSellers");

            migrationBuilder.CreateIndex(
                name: "IX_PendingSellers_UserId",
                table: "PendingSellers",
                column: "UserId");
        }
    }
}
