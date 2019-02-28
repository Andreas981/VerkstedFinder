using Microsoft.EntityFrameworkCore.Migrations;

namespace VerkstedFinder.Context.Migrations
{
    public partial class FixForRolePermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_PermissionPermId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_PermissionPermId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "PermissionPermId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Permissions");

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    PermId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermId",
                        column: x => x.PermId,
                        principalTable: "Permissions",
                        principalColumn: "PermId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermId",
                table: "RolePermissions",
                column: "PermId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.AddColumn<int>(
                name: "PermissionPermId",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Permissions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PermissionPermId",
                table: "Roles",
                column: "PermissionPermId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_PermissionPermId",
                table: "Roles",
                column: "PermissionPermId",
                principalTable: "Permissions",
                principalColumn: "PermId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
