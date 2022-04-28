using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuzzuleQuestion.Migrations
{
    public partial class InitialMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_UserId",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AnswerId",
                table: "Users",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Answers_AnswerId",
                table: "Users",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "AnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Answers_AnswerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AnswerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserId",
                table: "Answers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Users_UserId",
                table: "Answers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
