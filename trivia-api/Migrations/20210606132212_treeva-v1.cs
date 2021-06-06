using Microsoft.EntityFrameworkCore.Migrations;

namespace trivia_api.Migrations
{
    public partial class treevav1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionAnswers",
                table: "Question");

            migrationBuilder.AlterColumn<string>(
                name: "SourceAPI",
                table: "Question",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Difficulty",
                table: "Question",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Question",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswer",
                table: "Question",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IncorrectAnswers",
                table: "Question",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "IncorrectAnswers",
                table: "Question");

            migrationBuilder.AlterColumn<int>(
                name: "SourceAPI",
                table: "Question",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Difficulty",
                table: "Question",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Question",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionAnswers",
                table: "Question",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
