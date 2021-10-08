using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class UpdatedPhotoEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBytes",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "FileContent",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileContentType",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "FileContentType",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Photos");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageBytes",
                table: "Photos",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
