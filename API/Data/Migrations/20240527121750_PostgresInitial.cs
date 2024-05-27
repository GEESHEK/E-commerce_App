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
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calibres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    Material = table.Column<string>(type: "text", nullable: true)
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
                    Material = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crystals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Colour = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true)
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
                    Duration = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerReserves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StrapBraceletMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Material = table.Column<string>(type: "text", nullable: true)
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
                    Type = table.Column<string>(type: "text", nullable: true)
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
                    Resistance = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterResistances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DialId = table.Column<int>(type: "integer", nullable: true),
                    CrystalId = table.Column<int>(type: "integer", nullable: true),
                    Lume = table.Column<bool>(type: "boolean", nullable: false),
                    CaseMaterialId = table.Column<int>(type: "integer", nullable: true),
                    StrapBraceletMaterialId = table.Column<int>(type: "integer", nullable: true),
                    WatchCaseMeasurementsId = table.Column<int>(type: "integer", nullable: true),
                    WaterResistanceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_CaseMaterials_CaseMaterialId",
                        column: x => x.CaseMaterialId,
                        principalTable: "CaseMaterials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cases_Crystals_CrystalId",
                        column: x => x.CrystalId,
                        principalTable: "Crystals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cases_Dial_DialId",
                        column: x => x.DialId,
                        principalTable: "Dial",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cases_StrapBraceletMaterials_StrapBraceletMaterialId",
                        column: x => x.StrapBraceletMaterialId,
                        principalTable: "StrapBraceletMaterials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cases_WatchCaseMeasurements_WatchCaseMeasurementsId",
                        column: x => x.WatchCaseMeasurementsId,
                        principalTable: "WatchCaseMeasurements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cases_WaterResistances_WaterResistanceId",
                        column: x => x.WaterResistanceId,
                        principalTable: "WaterResistances",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Watches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BrandId = table.Column<int>(type: "integer", nullable: true),
                    CaseId = table.Column<int>(type: "integer", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    MovementTypeId = table.Column<int>(type: "integer", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    WatchTypeId = table.Column<int>(type: "integer", nullable: true),
                    OtherSpecifications = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watches_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Watches_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Watches_MovementTypes_MovementTypeId",
                        column: x => x.MovementTypeId,
                        principalTable: "MovementTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Watches_WatchTypes_WatchTypeId",
                        column: x => x.WatchTypeId,
                        principalTable: "WatchTypes",
                        principalColumn: "Id");
                });

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
                name: "IX_CaseMaterials_Material",
                table: "CaseMaterials",
                column: "Material",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CaseMaterialId",
                table: "Cases",
                column: "CaseMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_CrystalId",
                table: "Cases",
                column: "CrystalId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_DialId",
                table: "Cases",
                column: "DialId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_StrapBraceletMaterialId",
                table: "Cases",
                column: "StrapBraceletMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_WatchCaseMeasurementsId",
                table: "Cases",
                column: "WatchCaseMeasurementsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_WaterResistanceId",
                table: "Cases",
                column: "WaterResistanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Crystals_Material",
                table: "Crystals",
                column: "Material",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dial_Colour",
                table: "Dial",
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
                name: "IX_Watches_BrandId",
                table: "Watches",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_CaseId",
                table: "Watches",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_MovementTypeId",
                table: "Watches",
                column: "MovementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_WatchTypeId",
                table: "Watches",
                column: "WatchTypeId");

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
                name: "Calibres");

            migrationBuilder.DropTable(
                name: "PowerReserves");

            migrationBuilder.DropTable(
                name: "Watches");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "MovementTypes");

            migrationBuilder.DropTable(
                name: "WatchTypes");

            migrationBuilder.DropTable(
                name: "CaseMaterials");

            migrationBuilder.DropTable(
                name: "Crystals");

            migrationBuilder.DropTable(
                name: "Dial");

            migrationBuilder.DropTable(
                name: "StrapBraceletMaterials");

            migrationBuilder.DropTable(
                name: "WatchCaseMeasurements");

            migrationBuilder.DropTable(
                name: "WaterResistances");
        }
    }
}
