using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonReviewApi.Migrations
{
    public partial class PLEASEWORKBITCH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Kanto" },
                    { 2, "Aroyan" },
                    { 3, "Evelion" }
                });

            migrationBuilder.InsertData(
                table: "Pokemon",
                columns: new[] { "Id", "Damage", "Health", "Name" },
                values: new object[,]
                {
                    { 1, 10, 100, "Poki-Kun" },
                    { 2, 5, 250, "Hexor" },
                    { 3, 2, 150, "Gringo" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "CountryId", "FirstName", "LastName", "Team" },
                values: new object[,]
                {
                    { 1, 1, "Joe", "Biden", "Valar" },
                    { 2, 2, "Steven", "Seagull", "Mystico" },
                    { 3, 3, "Peter", "Griffin", "Instincto" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pokemon",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
