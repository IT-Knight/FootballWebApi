using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballWebApi.Migrations
{
    public partial class _minorFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Teams_WinnerTeamId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_WinnerTeamId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "WinnerTeamId",
                table: "Matches");

            migrationBuilder.AddColumn<string>(
                name: "WinnerTeam",
                table: "Matches",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinnerTeam",
                table: "Matches");

            migrationBuilder.AddColumn<int>(
                name: "WinnerTeamId",
                table: "Matches",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerTeamId",
                table: "Matches",
                column: "WinnerTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Teams_WinnerTeamId",
                table: "Matches",
                column: "WinnerTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
