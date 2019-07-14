using Microsoft.EntityFrameworkCore.Migrations;

namespace BullsAndCows.Data.Migrations
{
    public partial class asdf3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIGuess_Games_GameId",
                table: "AIGuess");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuess_Games_GameId",
                table: "UserGuess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGuess",
                table: "UserGuess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AIGuess",
                table: "AIGuess");

            migrationBuilder.RenameTable(
                name: "UserGuess",
                newName: "UserGuesses");

            migrationBuilder.RenameTable(
                name: "AIGuess",
                newName: "AIGuesses");

            migrationBuilder.RenameIndex(
                name: "IX_UserGuess_GameId",
                table: "UserGuesses",
                newName: "IX_UserGuesses_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_AIGuess_GameId",
                table: "AIGuesses",
                newName: "IX_AIGuesses_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGuesses",
                table: "UserGuesses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AIGuesses",
                table: "AIGuesses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AIGuesses_Games_GameId",
                table: "AIGuesses",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuesses_Games_GameId",
                table: "UserGuesses",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIGuesses_Games_GameId",
                table: "AIGuesses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuesses_Games_GameId",
                table: "UserGuesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGuesses",
                table: "UserGuesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AIGuesses",
                table: "AIGuesses");

            migrationBuilder.RenameTable(
                name: "UserGuesses",
                newName: "UserGuess");

            migrationBuilder.RenameTable(
                name: "AIGuesses",
                newName: "AIGuess");

            migrationBuilder.RenameIndex(
                name: "IX_UserGuesses_GameId",
                table: "UserGuess",
                newName: "IX_UserGuess_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_AIGuesses_GameId",
                table: "AIGuess",
                newName: "IX_AIGuess_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGuess",
                table: "UserGuess",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AIGuess",
                table: "AIGuess",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AIGuess_Games_GameId",
                table: "AIGuess",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuess_Games_GameId",
                table: "UserGuess",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
