using Microsoft.EntityFrameworkCore.Migrations;

namespace VerkstedFinder.Context.Migrations
{
    public partial class MabyARoleFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionPermId",
                table: "Roles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PermissionPermId",
                table: "Roles",
                column: "PermissionPermId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_PermissionPermId",
                table: "Roles",
                column: "PermissionPermId",
                principalTable: "Permissions",
                principalColumn: "PermId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_PermissionPermId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_PermissionPermId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "PermissionPermId",
                table: "Roles");
        }
    }
}
