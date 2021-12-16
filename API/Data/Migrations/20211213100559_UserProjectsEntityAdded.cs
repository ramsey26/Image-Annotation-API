using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class UserProjectsEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_AppUserId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Photos",
                newName: "UserProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_AppUserId",
                table: "Photos",
                newName: "IX_Photos_UserProjectId");

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProjects_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_AppUserId",
                table: "UserProjects",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_UserProjects_UserProjectId",
                table: "Photos",
                column: "UserProjectId",
                principalTable: "UserProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_UserProjects_UserProjectId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.RenameColumn(
                name: "UserProjectId",
                table: "Photos",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_UserProjectId",
                table: "Photos",
                newName: "IX_Photos_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_AppUserId",
                table: "Photos",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
