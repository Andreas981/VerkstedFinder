using Microsoft.EntityFrameworkCore.Migrations;

namespace VerkstedFinder.Context.Migrations
{
    public partial class UpdateAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId1",
                table: "Permissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId1",
                table: "Permissions",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId1",
                table: "Permissions",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId1",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_RoleId1",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "Permissions");
        }
    }
}
