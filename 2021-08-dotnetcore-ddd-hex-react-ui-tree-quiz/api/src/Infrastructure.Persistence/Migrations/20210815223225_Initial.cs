using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Root = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Name", "Root" },
                values: new object[] { 2, "Yes / No", "{\"Id\":3,\"Text\":\"Do you want to start?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":4,\"Text\":\"second step if yes\",\"Children\":[]}},{\"Relation\":\"no\",\"Node\":{\"Id\":5,\"Text\":\"Yeah! Thanks for not playing!\"}}]}" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Name", "Root" },
                values: new object[] { 6, "Multi nodes", "{\"Id\":7,\"Text\":\"Do you want to start?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":8,\"Text\":\"second step if yes\",\"Children\":[]}},{\"Relation\":\"no\",\"Node\":{\"Id\":9,\"Text\":\"Yeah! Thanks for not playing!\"}},{\"Relation\":\"not sure\",\"Node\":{\"Id\":10,\"Text\":\"Hmm... Are you a human?\",\"Children\":[{\"Relation\":\"not sure\",\"Node\":{\"Id\":11,\"Text\":\"You have chosen the right one.\"}},{\"Relation\":\"not sure\",\"Node\":{\"Id\":12,\"Text\":\"You have chosen the left one.\"}}]}}]}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
