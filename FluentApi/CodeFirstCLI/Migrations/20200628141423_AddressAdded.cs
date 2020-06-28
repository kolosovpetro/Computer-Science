using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CodeFirstCLI.Migrations
{
    public partial class AddressAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street = table.Column<string>(nullable: true),
                    house_number = table.Column<int>(nullable: false),
                    apt_number = table.Column<int>(nullable: false),
                    post_code = table.Column<int>(nullable: false),
                    city = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    team_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    team_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.team_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firstname = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    team_id = table.Column<int>(nullable: false),
                    address_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pkey", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_users_address_address_id",
                        column: x => x.address_id,
                        principalTable: "address",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "team_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "address",
                columns: new[] { "address_id", "apt_number", "city", "country", "house_number", "post_code", "street" },
                values: new object[] { 1, 17, "Poznan", "PL", 121, 1337, "Polweiska str." });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "team_id", "team_name" },
                values: new object[] { 1, "WSB Dream team" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address_id", "firstname", "lastname", "team_id" },
                values: new object[] { 4, 1, "Michail", "Ivanov", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_users_address_id",
                table: "users",
                column: "address_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_team_id",
                table: "users",
                column: "team_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
