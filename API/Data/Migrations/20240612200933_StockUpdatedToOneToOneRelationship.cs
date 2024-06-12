using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class StockUpdatedToOneToOneRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watches_Stocks_StockId",
                table: "Watches");

            migrationBuilder.DropIndex(
                name: "IX_Watches_StockId",
                table: "Watches");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Watches");

            migrationBuilder.AddColumn<int>(
                name: "WatchId",
                table: "Stocks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_WatchId",
                table: "Stocks",
                column: "WatchId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Watches_WatchId",
                table: "Stocks",
                column: "WatchId",
                principalTable: "Watches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Watches_WatchId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_WatchId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "WatchId",
                table: "Stocks");

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Watches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Watches_StockId",
                table: "Watches",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_Stocks_StockId",
                table: "Watches",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
