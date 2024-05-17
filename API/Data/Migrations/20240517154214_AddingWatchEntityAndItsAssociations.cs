using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingWatchEntityAndItsAssociations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Watches",
                newName: "OtherSpecifications");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Watches",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Watches",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Watches",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovementType",
                table: "Watches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Watches",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Watches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WatchType",
                table: "Watches",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calibres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calibres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Colour = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerReserves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Duration = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerReserves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WatchCaseMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Diameter = table.Column<double>(type: "REAL", nullable: false),
                    Thickness = table.Column<double>(type: "REAL", nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    LugWidth = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchCaseMeasurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DialId = table.Column<int>(type: "INTEGER", nullable: true),
                    Crystal = table.Column<int>(type: "INTEGER", nullable: false),
                    Lume = table.Column<bool>(type: "INTEGER", nullable: false),
                    CaseMaterial = table.Column<int>(type: "INTEGER", nullable: false),
                    StrapBraceletMaterial = table.Column<int>(type: "INTEGER", nullable: false),
                    WatchCaseMeasurementsId = table.Column<int>(type: "INTEGER", nullable: true),
                    WaterResistance = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Dial_DialId",
                        column: x => x.DialId,
                        principalTable: "Dial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cases_WatchCaseMeasurements_WatchCaseMeasurementsId",
                        column: x => x.WatchCaseMeasurementsId,
                        principalTable: "WatchCaseMeasurements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Watches_BrandId",
                table: "Watches",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_CaseId",
                table: "Watches",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Name",
                table: "Brand",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calibres_Name",
                table: "Calibres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_DialId",
                table: "Cases",
                column: "DialId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_WatchCaseMeasurementsId",
                table: "Cases",
                column: "WatchCaseMeasurementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Dial_Colour",
                table: "Dial",
                column: "Colour",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerReserves_Duration",
                table: "PowerReserves",
                column: "Duration",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_Brand_BrandId",
                table: "Watches",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Watches_Cases_CaseId",
                table: "Watches",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Watches_Brand_BrandId",
                table: "Watches");

            migrationBuilder.DropForeignKey(
                name: "FK_Watches_Cases_CaseId",
                table: "Watches");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Calibres");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "PowerReserves");

            migrationBuilder.DropTable(
                name: "Dial");

            migrationBuilder.DropTable(
                name: "WatchCaseMeasurements");

            migrationBuilder.DropIndex(
                name: "IX_Watches_BrandId",
                table: "Watches");

            migrationBuilder.DropIndex(
                name: "IX_Watches_CaseId",
                table: "Watches");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Watches");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Watches");

            migrationBuilder.DropColumn(
                name: "MovementType",
                table: "Watches");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Watches");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Watches");

            migrationBuilder.DropColumn(
                name: "WatchType",
                table: "Watches");

            migrationBuilder.RenameColumn(
                name: "OtherSpecifications",
                table: "Watches",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Watches",
                newName: "Brand");
        }
    }
}
