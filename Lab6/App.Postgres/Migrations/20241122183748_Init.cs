using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LifeCyclePhases",
                columns: table => new
                {
                    LifeCycleCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LifeCycleName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LifeCycleDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeCyclePhases", x => x.LifeCycleCode);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationDetails = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "RefAssetCategories",
                columns: table => new
                {
                    AssetCategoryCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    AssetCategoryDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAssetCategories", x => x.AssetCategoryCode);
                });

            migrationBuilder.CreateTable(
                name: "RefSizes",
                columns: table => new
                {
                    SizeCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    SizeDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefSizes", x => x.SizeCode);
                });

            migrationBuilder.CreateTable(
                name: "RefStatuses",
                columns: table => new
                {
                    StatusCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    StatusDescription = table.Column<string>(type: "character varying(155)", maxLength: 155, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefStatuses", x => x.StatusCode);
                });

            migrationBuilder.CreateTable(
                name: "ResponsibleParties",
                columns: table => new
                {
                    PartyId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartyDetails = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsibleParties", x => x.PartyId);
                });

            migrationBuilder.CreateTable(
                name: "RefAssetSupertypes",
                columns: table => new
                {
                    AssetSupertypeCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    AssetSupertypeDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AssetCategoryCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAssetSupertypes", x => x.AssetSupertypeCode);
                    table.ForeignKey(
                        name: "FK_RefAssetSupertypes_RefAssetCategories_AssetCategoryCode",
                        column: x => x.AssetCategoryCode,
                        principalTable: "RefAssetCategories",
                        principalColumn: "AssetCategoryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefAssetTypes",
                columns: table => new
                {
                    AssetTypeCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    AssetTypeDescription = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AssetSupertypeCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefAssetTypes", x => x.AssetTypeCode);
                    table.ForeignKey(
                        name: "FK_RefAssetTypes_RefAssetSupertypes_AssetSupertypeCode",
                        column: x => x.AssetSupertypeCode,
                        principalTable: "RefAssetSupertypes",
                        principalColumn: "AssetSupertypeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssetTypeCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    SizeCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    AssetName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    OtherDetails = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Assets_RefAssetTypes_AssetTypeCode",
                        column: x => x.AssetTypeCode,
                        principalTable: "RefAssetTypes",
                        principalColumn: "AssetTypeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assets_RefSizes_SizeCode",
                        column: x => x.SizeCode,
                        principalTable: "RefSizes",
                        principalColumn: "SizeCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetsLifeCycleEvents",
                columns: table => new
                {
                    AssetLifeCycleEventId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssetId = table.Column<Guid>(type: "uuid", nullable: false),
                    LifeCycleCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartyId = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    DateFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsLifeCycleEvents", x => x.AssetLifeCycleEventId);
                    table.ForeignKey(
                        name: "FK_AssetsLifeCycleEvents_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsLifeCycleEvents_LifeCyclePhases_LifeCycleCode",
                        column: x => x.LifeCycleCode,
                        principalTable: "LifeCyclePhases",
                        principalColumn: "LifeCycleCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsLifeCycleEvents_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsLifeCycleEvents_RefStatuses_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "RefStatuses",
                        principalColumn: "StatusCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetsLifeCycleEvents_ResponsibleParties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "ResponsibleParties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetTypeCode",
                table: "Assets",
                column: "AssetTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SizeCode",
                table: "Assets",
                column: "SizeCode");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsLifeCycleEvents_AssetId",
                table: "AssetsLifeCycleEvents",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsLifeCycleEvents_LifeCycleCode",
                table: "AssetsLifeCycleEvents",
                column: "LifeCycleCode");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsLifeCycleEvents_LocationId",
                table: "AssetsLifeCycleEvents",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsLifeCycleEvents_PartyId",
                table: "AssetsLifeCycleEvents",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsLifeCycleEvents_StatusCode",
                table: "AssetsLifeCycleEvents",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_RefAssetSupertypes_AssetCategoryCode",
                table: "RefAssetSupertypes",
                column: "AssetCategoryCode");

            migrationBuilder.CreateIndex(
                name: "IX_RefAssetTypes_AssetSupertypeCode",
                table: "RefAssetTypes",
                column: "AssetSupertypeCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetsLifeCycleEvents");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "LifeCyclePhases");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "RefStatuses");

            migrationBuilder.DropTable(
                name: "ResponsibleParties");

            migrationBuilder.DropTable(
                name: "RefAssetTypes");

            migrationBuilder.DropTable(
                name: "RefSizes");

            migrationBuilder.DropTable(
                name: "RefAssetSupertypes");

            migrationBuilder.DropTable(
                name: "RefAssetCategories");
        }
    }
}
