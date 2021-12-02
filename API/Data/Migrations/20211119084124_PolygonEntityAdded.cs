using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class PolygonEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Polygons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolygonNo = table.Column<int>(type: "int", nullable: false),
                    StartX = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartY = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndX = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndY = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polygons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Polygons_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolygonNo = table.Column<int>(type: "int", nullable: false),
                    X1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Y1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    X2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Y2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolygonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineSegments_Polygons_PolygonId",
                        column: x => x.PolygonId,
                        principalTable: "Polygons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineSegments_PolygonId",
                table: "LineSegments",
                column: "PolygonId");

            migrationBuilder.CreateIndex(
                name: "IX_Polygons_PhotoId",
                table: "Polygons",
                column: "PhotoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineSegments");

            migrationBuilder.DropTable(
                name: "Polygons");
        }
    }
}
