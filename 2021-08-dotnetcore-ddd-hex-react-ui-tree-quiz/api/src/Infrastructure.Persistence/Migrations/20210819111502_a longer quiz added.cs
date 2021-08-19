using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class alongerquizadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Name", "Root" },
                values: new object[] { 12, "Multi nodes test", "{\"Id\":13,\"Text\":\"Do you want to start?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":14,\"Text\":\"You clicked 'yes', great. That's the end\"}},{\"Relation\":\"no\",\"Node\":{\"Id\":15,\"Text\":\"Yeah! Thanks for NOT playing!\"}},{\"Relation\":\"not sure\",\"Node\":{\"Id\":16,\"Text\":\"Hmm... Are you a human?\",\"Children\":[{\"Relation\":\"not sure\",\"Node\":{\"Id\":17,\"Text\":\"You have chosen the right one.\"}},{\"Relation\":\"not sure\",\"Node\":{\"Id\":18,\"Text\":\"You have chosen the left one.\"}}]}}]}" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Name", "Root" },
                values: new object[] { 19, "Long Quiz", "{\"Id\":20,\"Text\":\"How are you?\",\"Children\":[{\"Relation\":\"fine\",\"Node\":{\"Id\":21,\"Text\":\"Not bad, not bad. Are you waiting for a weekend to have a rest?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":1,\"Text\":\"Nice to hear. And what will you do?\",\"Children\":[{\"Relation\":\"drink beer\",\"Node\":{\"Id\":2,\"Text\":\"Dark or light?\",\"Children\":[{\"Relation\":\"dark\",\"Node\":{\"Id\":3,\"Text\":\"I will call you 'Dark Knight' now)\"}},{\"Relation\":\"light\",\"Node\":{\"Id\":4,\"Text\":\"Light is for girls, urgh... I have no more questions.\"}},{\"Relation\":\"Budweiser\",\"Node\":{\"Id\":5,\"Text\":\"Great choice! Feel free to fill you tanks!\"}}]}},{\"Relation\":\"do sports\",\"Node\":{\"Id\":6,\"Text\":\"Nice to hear. And what will you do?\",\"Children\":[{\"Relation\":\"lazy chillin'\",\"Node\":{\"Id\":7,\"Text\":\"Ha-ha! Okay, have a rest.\"}},{\"Relation\":\"Nike\",\"Node\":{\"Id\":8,\"Text\":\"Just do it!\"}}]}},{\"Relation\":\"lazy chillin'\",\"Node\":{\"Id\":9,\"Text\":\"Ha-ha! Okay, have a rest.\"}}]}},{\"Relation\":\"no\",\"Node\":{\"Id\":10,\"Text\":\"No? So you have no plan to feel better and answer 'brilliant' next time?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":11,\"Text\":\"Okay. Bye.\"}}]}}]}},{\"Relation\":\"brilliant\",\"Node\":{\"Id\":22,\"Text\":\"Great to hear! But I have not prepared another questions to you, rather than from the first option. So, are you waiting for a weekend to have a rest?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":1,\"Text\":\"Nice to hear. And what will you do?\",\"Children\":[{\"Relation\":\"drink beer\",\"Node\":{\"Id\":2,\"Text\":\"Dark or light?\",\"Children\":[{\"Relation\":\"dark\",\"Node\":{\"Id\":3,\"Text\":\"I will call you 'Dark Knight' now)\"}},{\"Relation\":\"light\",\"Node\":{\"Id\":4,\"Text\":\"Light is for girls, urgh... I have no more questions.\"}},{\"Relation\":\"Budweiser\",\"Node\":{\"Id\":5,\"Text\":\"Great choice! Feel free to fill you tanks!\"}}]}},{\"Relation\":\"do sports\",\"Node\":{\"Id\":6,\"Text\":\"Nice to hear. And what will you do?\",\"Children\":[{\"Relation\":\"lazy chillin'\",\"Node\":{\"Id\":7,\"Text\":\"Ha-ha! Okay, have a rest.\"}},{\"Relation\":\"Nike\",\"Node\":{\"Id\":8,\"Text\":\"Just do it!\"}}]}},{\"Relation\":\"lazy chillin'\",\"Node\":{\"Id\":9,\"Text\":\"Ha-ha! Okay, have a rest.\"}}]}},{\"Relation\":\"no\",\"Node\":{\"Id\":10,\"Text\":\"No? So you have no plan to feel better and answer 'brilliant' next time?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":11,\"Text\":\"Okay. Bye.\"}}]}}]}}]}" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Name", "Root" },
                values: new object[] { 2, "Yes / No", "{\"Id\":3,\"Text\":\"Do you want to start?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":4,\"Text\":\"second step if yes\",\"Children\":[]}},{\"Relation\":\"no\",\"Node\":{\"Id\":5,\"Text\":\"Yeah! Thanks for not playing!\"}}]}" });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Name", "Root" },
                values: new object[] { 6, "Multi nodes", "{\"Id\":7,\"Text\":\"Do you want to start?\",\"Children\":[{\"Relation\":\"yes\",\"Node\":{\"Id\":8,\"Text\":\"second step if yes\",\"Children\":[]}},{\"Relation\":\"no\",\"Node\":{\"Id\":9,\"Text\":\"Yeah! Thanks for not playing!\"}},{\"Relation\":\"not sure\",\"Node\":{\"Id\":10,\"Text\":\"Hmm... Are you a human?\",\"Children\":[{\"Relation\":\"not sure\",\"Node\":{\"Id\":11,\"Text\":\"You have chosen the right one.\"}},{\"Relation\":\"not sure\",\"Node\":{\"Id\":12,\"Text\":\"You have chosen the left one.\"}}]}}]}" });
        }
    }
}
