using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstCLI.Migrations
{
    public partial class NullableForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "address",
                keyColumn: "address_id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "address_id",
                table: "users",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "address",
                columns: new[] { "address_id", "apt_number", "city", "country", "house_number", "post_code", "street" },
                values: new object[] { 1, 17, "Poznan", "PL", 121, 1337, "Polweiska str." });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address_id", "firstname", "lastname", "team_id" },
                values: new object[,]
                {
                    { 1, null, "Ivan", "Ivanov", 1 },
                    { 3, null, "Georgii", "Ivanov", 1 },
                    { 2, null, "Alex", "Ivanov", 1 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address_id", "firstname", "lastname", "team_id" },
                values: new object[] { 4, 1, "Michail", "Ivanov", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "address",
                keyColumn: "address_id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "address_id",
                table: "users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "address",
                columns: new[] { "address_id", "apt_number", "city", "country", "house_number", "post_code", "street" },
                values: new object[] { 1, 17, "Poznan", "PL", 121, 1337, "Polweiska str." });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                column: "address_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2,
                column: "address_id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 3,
                column: "address_id",
                value: 1);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "address_id", "firstname", "lastname", "team_id" },
                values: new object[] { 4, 1, "Michail", "Ivanov", 1 });
        }
    }
}
