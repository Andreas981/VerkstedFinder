using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VerkstedFinder.Context.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poststeds",
                columns: table => new
                {
                    Postnr = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PoststedName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poststeds", x => x.Postnr);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    Ws_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ws_name = table.Column<string>(nullable: false),
                    Ws_orgnumber = table.Column<string>(nullable: false),
                    Ws_address = table.Column<string>(nullable: false),
                    Ws_poststedPostnr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshops", x => x.Ws_id);
                    table.ForeignKey(
                        name: "FK_Workshops_Poststeds_Ws_poststedPostnr",
                        column: x => x.Ws_poststedPostnr,
                        principalTable: "Poststeds",
                        principalColumn: "Postnr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_firstname = table.Column<string>(nullable: false),
                    User_lastname = table.Column<string>(nullable: false),
                    User_username = table.Column<string>(nullable: false),
                    User_password = table.Column<string>(nullable: false),
                    User_roleRoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_User_roleRoleId",
                        column: x => x.User_roleRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_User_roleRoleId",
                table: "Users",
                column: "User_roleRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Workshops_Ws_poststedPostnr",
                table: "Workshops",
                column: "Ws_poststedPostnr");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Workshops");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Poststeds");
        }
    }
}
