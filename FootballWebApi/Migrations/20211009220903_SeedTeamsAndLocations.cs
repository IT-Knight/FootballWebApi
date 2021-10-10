using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballWebApi.Migrations
{
    public partial class SeedTeamsAndLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "MatchLocations",
                newName: "Location");

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 1, "Liverpool, England" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 18, "Madrid, Spain" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 17, "Athens, Greece" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 16, "Rome, Italy" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 15, "Lisbon, Portugal" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 14, "Moscow, Russia" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 13, "Rome, Italy" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 12, "Rio de Janeiro, Brazil" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 11, "Glasgow, Scotland" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 19, "Rome, Italy" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 9, "Rio De Janeiro, Brazil" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 8, "Barcelona, Spain" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 7, "Milan, Italy" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 6, "London, England" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 5, "Mexico City, Mexico" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 4, "Madrid, Spain" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 3, "Buenos Aires, Argentina" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 2, "Manchester, England" });

            migrationBuilder.InsertData(
                table: "MatchLocations",
                columns: new[] { "Id", "Location" },
                values: new object[] { 10, "Mexico City, Mexico" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "New York Giants" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Philadelphia Eagles" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 16, "Washington Football Team" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "Seattle Seahawks" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 15, "Tampa Bay Buccaneers" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "New Orleans Saints" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "San Francisco 49ers" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Minnesota Vikings" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Dallas Cowboys" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Green Bay Packers" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Detroit Lions" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Chicago Bears" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Carolina Panthers" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Arizona Cardinals" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Atlanta Falcons" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 17, "Tennessee Titans" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Los Angeles Rams" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[] { 18, "Pittsburgh Steelers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MatchLocations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "MatchLocations",
                newName: "City");
        }
    }
}
