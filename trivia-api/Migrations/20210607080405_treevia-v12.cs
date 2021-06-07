using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace trivia_api.Migrations
{
    public partial class treeviav12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lobby",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Members = table.Column<string>(nullable: true),
                    MembersCounter = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    LobbyNumber = table.Column<string>(nullable: true),
                    Published = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lobby", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lobby");
        }
    }
}
