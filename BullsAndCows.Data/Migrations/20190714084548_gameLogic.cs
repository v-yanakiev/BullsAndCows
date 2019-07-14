using Microsoft.EntityFrameworkCore.Migrations;

namespace BullsAndCows.Data.Migrations
{
    public partial class gameLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Games",
                newName: "WonByAI");

            migrationBuilder.AddColumn<int>(
                name: "BullNumber",
                table: "UserGuesses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CowNumber",
                table: "UserGuesses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BullNumber",
                table: "AIGuesses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CowNumber",
                table: "AIGuesses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BullNumber",
                table: "UserGuesses");

            migrationBuilder.DropColumn(
                name: "CowNumber",
                table: "UserGuesses");

            migrationBuilder.DropColumn(
                name: "BullNumber",
                table: "AIGuesses");

            migrationBuilder.DropColumn(
                name: "CowNumber",
                table: "AIGuesses");

            migrationBuilder.RenameColumn(
                name: "WonByAI",
                table: "Games",
                newName: "IsActive");
        }
    }
}
