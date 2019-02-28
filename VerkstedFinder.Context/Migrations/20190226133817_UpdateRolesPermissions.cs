using Microsoft.EntityFrameworkCore.Migrations;

namespace VerkstedFinder.Context.Migrations
{
    public partial class UpdateRolesPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_roleRoleId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_roleRoleId",
                table: "Users",
                column: "User_roleRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_User_roleRoleId",
                table: "Users",
                column: "User_roleRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_User_roleRoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_User_roleRoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "User_roleRoleId",
                table: "Users");
        }
    }
}
