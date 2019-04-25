using Microsoft.EntityFrameworkCore.Migrations;

namespace VerkstedFinder.Context.Migrations
{
    public partial class AddedNewPostnr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Poststeds_Postnr1",
                table: "Workshops");

            migrationBuilder.RenameColumn(
                name: "Postnr1",
                table: "Workshops",
                newName: "Postnr1Postnr");

            migrationBuilder.RenameIndex(
                name: "IX_Workshops_Postnr1",
                table: "Workshops",
                newName: "IX_Workshops_Postnr1Postnr");

            migrationBuilder.AddColumn<string>(
                name: "User_password",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Poststeds_Postnr1Postnr",
                table: "Workshops",
                column: "Postnr1Postnr",
                principalTable: "Poststeds",
                principalColumn: "Postnr",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Poststeds_Postnr1Postnr",
                table: "Workshops");

            migrationBuilder.DropColumn(
                name: "User_password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Postnr1Postnr",
                table: "Workshops",
                newName: "Postnr1");

            migrationBuilder.RenameIndex(
                name: "IX_Workshops_Postnr1Postnr",
                table: "Workshops",
                newName: "IX_Workshops_Postnr1");

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Poststeds_Postnr1",
                table: "Workshops",
                column: "Postnr1",
                principalTable: "Poststeds",
                principalColumn: "Postnr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
