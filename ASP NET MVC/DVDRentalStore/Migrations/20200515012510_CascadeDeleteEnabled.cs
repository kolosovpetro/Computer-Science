using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DVDRentalStore.Migrations
{
    public partial class CascadeDeleteEnabled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actors",
                columns: table => new
                {
                    actor_id = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(type: "character varying", nullable: true),
                    last_name = table.Column<string>(type: "character varying", nullable: true),
                    birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("actors_pkey", x => x.actor_id);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    client_id = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(type: "character varying", nullable: true),
                    last_name = table.Column<string>(type: "character varying", nullable: true),
                    birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("clients_pkey", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(type: "character varying", nullable: true),
                    last_name = table.Column<string>(type: "character varying", nullable: true),
                    city = table.Column<string>(type: "character varying", nullable: true),
                    salary = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("employees_pkey", x => x.employee_id);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    movie_id = table.Column<int>(nullable: false),
                    title = table.Column<string>(type: "character varying", nullable: false),
                    year = table.Column<int>(nullable: false),
                    age_restriction = table.Column<int>(nullable: true),
                    price = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("movies_pkey", x => x.movie_id);
                });

            migrationBuilder.CreateTable(
                name: "copies",
                columns: table => new
                {
                    copy_id = table.Column<int>(nullable: false),
                    available = table.Column<bool>(nullable: true),
                    movie_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("copies_pkey", x => x.copy_id);
                    table.ForeignKey(
                        name: "copies_movie_id_fkey",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "movie_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "starring",
                columns: table => new
                {
                    actor_id = table.Column<int>(nullable: false),
                    movie_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("starring_pkey", x => new { x.actor_id, x.movie_id });
                    table.ForeignKey(
                        name: "starring_actor_id_fkey",
                        column: x => x.actor_id,
                        principalTable: "actors",
                        principalColumn: "actor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "starring_movie_id_fkey",
                        column: x => x.movie_id,
                        principalTable: "movies",
                        principalColumn: "movie_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rentals",
                columns: table => new
                {
                    copy_id = table.Column<int>(nullable: false),
                    client_id = table.Column<int>(nullable: false),
                    date_of_rental = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    date_of_return = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("rentals_pkey", x => new { x.copy_id, x.client_id });
                    table.ForeignKey(
                        name: "rentals_client_id_fkey",
                        column: x => x.client_id,
                        principalTable: "clients",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "rentals_copy_id_fkey",
                        column: x => x.copy_id,
                        principalTable: "copies",
                        principalColumn: "copy_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_copies_movie_id",
                table: "copies",
                column: "movie_id");

            migrationBuilder.CreateIndex(
                name: "IX_rentals_client_id",
                table: "rentals",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_starring_movie_id",
                table: "starring",
                column: "movie_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "rentals");

            migrationBuilder.DropTable(
                name: "starring");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "copies");

            migrationBuilder.DropTable(
                name: "actors");

            migrationBuilder.DropTable(
                name: "movies");
        }
    }
}
