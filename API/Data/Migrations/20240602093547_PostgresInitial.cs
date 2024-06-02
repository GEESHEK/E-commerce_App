using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class PostgresInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calibres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calibres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Material = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crystals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Material = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crystals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Colour = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerReserves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Duration = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerReserves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StrapBraceletMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Material = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrapBraceletMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WatchCaseMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Diameter = table.Column<double>(type: "double precision", nullable: false),
                    Thickness = table.Column<double>(type: "double precision", nullable: false),
                    Length = table.Column<double>(type: "double precision", nullable: false),
                    LugWidth = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchCaseMeasurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WatchTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterResistances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Resistance = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterResistances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Watches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    CalibreId = table.Column<int>(type: "integer", nullable: false),
                    CaseMaterialId = table.Column<int>(type: "integer", nullable: false),
                    CrystalId = table.Column<int>(type: "integer", nullable: false),
                    DialId = table.Column<int>(type: "integer", nullable: false),
                    Lume = table.Column<bool>(type: "boolean", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    MovementTypeId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PowerReserveId = table.Column<int>(type: "integer", nullable: false),
                    StockId = table.Column<int>(type: "integer", nullable: false),
                    StrapBraceletMaterialId = table.Column<int>(type: "integer", nullable: false),
                    WatchCaseMeasurementsId = table.Column<int>(type: "integer", nullable: false),
                    WatchTypeId = table.Column<int>(type: "integer", nullable: false),
                    WaterResistanceId = table.Column<int>(type: "integer", nullable: false),
                    OtherSpecifications = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watches_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_Calibres_CalibreId",
                        column: x => x.CalibreId,
                        principalTable: "Calibres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_CaseMaterials_CaseMaterialId",
                        column: x => x.CaseMaterialId,
                        principalTable: "CaseMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_Crystals_CrystalId",
                        column: x => x.CrystalId,
                        principalTable: "Crystals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_Dials_DialId",
                        column: x => x.DialId,
                        principalTable: "Dials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_MovementTypes_MovementTypeId",
                        column: x => x.MovementTypeId,
                        principalTable: "MovementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_PowerReserves_PowerReserveId",
                        column: x => x.PowerReserveId,
                        principalTable: "PowerReserves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_StrapBraceletMaterials_StrapBraceletMaterialId",
                        column: x => x.StrapBraceletMaterialId,
                        principalTable: "StrapBraceletMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_WatchCaseMeasurements_WatchCaseMeasurementsId",
                        column: x => x.WatchCaseMeasurementsId,
                        principalTable: "WatchCaseMeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_WatchTypes_WatchTypeId",
                        column: x => x.WatchTypeId,
                        principalTable: "WatchTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Watches_WaterResistances_WaterResistanceId",
                        column: x => x.WaterResistanceId,
                        principalTable: "WaterResistances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calibres_Name",
                table: "Calibres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseMaterials_Material",
                table: "CaseMaterials",
                column: "Material",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crystals_Material",
                table: "Crystals",
                column: "Material",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dials_Colour",
                table: "Dials",
                column: "Colour",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovementTypes_Type",
                table: "MovementTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PowerReserves_Duration",
                table: "PowerReserves",
                column: "Duration",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrapBraceletMaterials_Material",
                table: "StrapBraceletMaterials",
                column: "Material",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchCaseMeasurements_Diameter_Length_LugWidth_Thickness",
                table: "WatchCaseMeasurements",
                columns: new[] { "Diameter", "Length", "LugWidth", "Thickness" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Watches_BrandId",
                table: "Watches",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_CalibreId",
                table: "Watches",
                column: "CalibreId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_CaseMaterialId",
                table: "Watches",
                column: "CaseMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_CrystalId",
                table: "Watches",
                column: "CrystalId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_DialId",
                table: "Watches",
                column: "DialId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_MovementTypeId",
                table: "Watches",
                column: "MovementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_PowerReserveId",
                table: "Watches",
                column: "PowerReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_Reference",
                table: "Watches",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Watches_StockId",
                table: "Watches",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_StrapBraceletMaterialId",
                table: "Watches",
                column: "StrapBraceletMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_WatchCaseMeasurementsId",
                table: "Watches",
                column: "WatchCaseMeasurementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_WatchTypeId",
                table: "Watches",
                column: "WatchTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_WaterResistanceId",
                table: "Watches",
                column: "WaterResistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchTypes_Type",
                table: "WatchTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaterResistances_Resistance",
                table: "WaterResistances",
                column: "Resistance",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Watches");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Calibres");

            migrationBuilder.DropTable(
                name: "CaseMaterials");

            migrationBuilder.DropTable(
                name: "Crystals");

            migrationBuilder.DropTable(
                name: "Dials");

            migrationBuilder.DropTable(
                name: "MovementTypes");

            migrationBuilder.DropTable(
                name: "PowerReserves");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "StrapBraceletMaterials");

            migrationBuilder.DropTable(
                name: "WatchCaseMeasurements");

            migrationBuilder.DropTable(
                name: "WatchTypes");

            migrationBuilder.DropTable(
                name: "WaterResistances");
        }
    }
}
