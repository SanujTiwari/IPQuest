using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IPQuest.Migrations
{
    /// <inheritdoc />
    public partial class SeedQuizQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Text", "TopicId" },
                values: new object[,]
                {
                    { 1, "Which of these is usually protected by copyright?", 1 },
                    { 2, "Who generally owns copyright in an original song created by a person?", 1 },
                    { 3, "Which action may violate copyright?", 1 },
                    { 4, "What does a trademark mainly help identify?", 2 },
                    { 5, "Which symbol is commonly associated with an unregistered trademark?", 2 },
                    { 6, "Which of these can be protected as a trademark?", 2 },
                    { 7, "What does a patent protect?", 3 },
                    { 8, "What is an invention generally required to be for patent protection?", 3 },
                    { 9, "Which of these could potentially be patented?", 3 },
                    { 10, "What is a trade secret?", 4 },
                    { 11, "Which of these could be a trade secret?", 4 },
                    { 12, "What is important for keeping a trade secret protected?", 4 }
                });

            migrationBuilder.InsertData(
                table: "AnswerOptions",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, true, 1, "A song" },
                    { 2, false, 1, "A company logo" },
                    { 3, false, 1, "A new machine" },
                    { 4, false, 1, "A secret recipe" },
                    { 5, true, 2, "The creator" },
                    { 6, false, 2, "Every person who hears it" },
                    { 7, false, 2, "The nearest shop" },
                    { 8, false, 2, "Nobody" },
                    { 9, true, 3, "Copying a protected work without permission" },
                    { 10, false, 3, "Creating your own drawing" },
                    { 11, false, 3, "Writing your own story" },
                    { 12, false, 3, "Making your own music" },
                    { 13, true, 4, "A brand or source of goods or services" },
                    { 14, false, 4, "A secret password" },
                    { 15, false, 4, "A computer program" },
                    { 16, false, 4, "A private diary" },
                    { 17, true, 5, "™" },
                    { 18, false, 5, "©" },
                    { 19, false, 5, "₹" },
                    { 20, false, 5, "#" },
                    { 21, true, 6, "A brand name or logo" },
                    { 22, false, 6, "A secret business formula" },
                    { 23, false, 6, "A scientific discovery" },
                    { 24, false, 6, "A personal password" },
                    { 25, true, 7, "An invention" },
                    { 26, false, 7, "A company slogan only" },
                    { 27, false, 7, "A person's nickname" },
                    { 28, false, 7, "A school timetable" },
                    { 29, true, 8, "New and inventive" },
                    { 30, false, 8, "Already copied" },
                    { 31, false, 8, "Kept only in a notebook" },
                    { 32, false, 8, "A brand name" },
                    { 33, true, 9, "A new technical device" },
                    { 34, false, 9, "A common word" },
                    { 35, false, 9, "A company color alone" },
                    { 36, false, 9, "A person's signature" },
                    { 37, true, 10, "Confidential business information with value" },
                    { 38, false, 10, "A public advertisement" },
                    { 39, false, 10, "A school uniform" },
                    { 40, false, 10, "A public website" },
                    { 41, true, 11, "A secret recipe" },
                    { 42, false, 11, "A public logo" },
                    { 43, false, 11, "A published book" },
                    { 44, false, 11, "A public advertisement" },
                    { 45, true, 12, "Keeping the information confidential" },
                    { 46, false, 12, "Publishing it online" },
                    { 47, false, 12, "Sharing it publicly" },
                    { 48, false, 12, "Posting it on social media" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
