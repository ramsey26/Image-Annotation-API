using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class UserProjectsEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_UserProjects_UserProjectId",
                table: "Photos");

            migrationBuilder.AlterColumn<int>(
                name: "UserProjectId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_UserProjects_UserProjectId",
                table: "Photos",
                column: "UserProjectId",
                principalTable: "UserProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_UserProjects_UserProjectId",
                table: "Photos");

            migrationBuilder.AlterColumn<int>(
                name: "UserProjectId",
                table: "Photos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_UserProjects_UserProjectId",
                table: "Photos",
                column: "UserProjectId",
                principalTable: "UserProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
