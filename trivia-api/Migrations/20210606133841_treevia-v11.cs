using Microsoft.EntityFrameworkCore.Migrations;

namespace trivia_api.Migrations
{
    public partial class treeviav11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Question");

            migrationBuilder.AddColumn<string>(
                name: "SourceAPI",
                table: "Question",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceAPI",
                table: "Question");

            migrationBuilder.AddColumn<string>(
                name: "QuestionId",
                table: "Question",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
