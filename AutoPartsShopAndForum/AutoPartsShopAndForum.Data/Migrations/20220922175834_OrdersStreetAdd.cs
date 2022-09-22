using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoPartsShopAndForum.Data.Migrations
{
    public partial class OrdersStreetAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TownId",
                table: "Orders",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Towns_TownId",
                table: "Orders",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Towns_TownId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TownId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "Orders");
        }
    }
}
