using Microsoft.EntityFrameworkCore.Migrations;

namespace VerkstedFinder.Context.Migrations
{
    public partial class RenamedPoststedInWorkshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Poststeds_Postnr1Postnr",
                table: "Workshops");

            migrationBuilder.RenameColumn(
                name: "Postnr1Postnr",
                table: "Workshops",
                newName: "Ws_poststedPostnr");

            migrationBuilder.RenameIndex(
                name: "IX_Workshops_Postnr1Postnr",
                table: "Workshops",
                newName: "IX_Workshops_Ws_poststedPostnr");

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Poststeds_Ws_poststedPostnr",
                table: "Workshops",
                column: "Ws_poststedPostnr",
                principalTable: "Poststeds",
                principalColumn: "Postnr",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Poststeds_Ws_poststedPostnr",
                table: "Workshops");

            migrationBuilder.RenameColumn(
                name: "Ws_poststedPostnr",
                table: "Workshops",
                newName: "Postnr1Postnr");

            migrationBuilder.RenameIndex(
                name: "IX_Workshops_Ws_poststedPostnr",
                table: "Workshops",
                newName: "IX_Workshops_Postnr1Postnr");

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Poststeds_Postnr1Postnr",
                table: "Workshops",
                column: "Postnr1Postnr",
                principalTable: "Poststeds",
                principalColumn: "Postnr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
