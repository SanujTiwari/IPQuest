using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IPQuest.Migrations
{
    /// <inheritdoc />
    public partial class SeedTopics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "Icon", "Title" },
                values: new object[,]
                {
                    { 1, "Protects original creative works such as books, music, videos, and artwork.", "©", "Copyright" },
                    { 2, "Protects brand names, logos, symbols, and other identifiers.", "™", "Trademark" },
                    { 3, "Protects new inventions and innovative technical solutions.", "⚙", "Patent" },
                    { 4, "Protects valuable confidential business information and know-how.", "🔐", "Trade Secret" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
