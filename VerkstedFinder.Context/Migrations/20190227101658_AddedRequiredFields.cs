using Microsoft.EntityFrameworkCore.Migrations;

namespace VerkstedFinder.Context.Migrations
{
    public partial class AddedRequiredFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_User_roleRoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Poststeds_Postnr1",
                table: "Workshops");

            migrationBuilder.DropColumn(
                name: "Ws_string",
                table: "Workshops");

            migrationBuilder.AlterColumn<string>(
                name: "Ws_name",
                table: "Workshops",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ws_address",
                table: "Workshops",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Postnr1",
                table: "Workshops",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "User_username",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "User_roleRoleId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "User_lastname",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "User_firstname",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PoststedName",
                table: "Poststeds",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Perm_name",
                table: "Permissions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_User_roleRoleId",
                table: "Users",
                column: "User_roleRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Poststeds_Postnr1",
                table: "Workshops",
                column: "Postnr1",
                principalTable: "Poststeds",
                principalColumn: "Postnr",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_User_roleRoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Poststeds_Postnr1",
                table: "Workshops");

            migrationBuilder.AlterColumn<string>(
                name: "Ws_name",
                table: "Workshops",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Ws_address",
                table: "Workshops",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Postnr1",
                table: "Workshops",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Ws_string",
                table: "Workshops",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "User_username",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "User_roleRoleId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "User_lastname",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "User_firstname",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PoststedName",
                table: "Poststeds",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Perm_name",
                table: "Permissions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_User_roleRoleId",
                table: "Users",
                column: "User_roleRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Poststeds_Postnr1",
                table: "Workshops",
                column: "Postnr1",
                principalTable: "Poststeds",
                principalColumn: "Postnr",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
