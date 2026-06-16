using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Options = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAnswer", "Options", "QuestionText" },
                values: new object[,]
                {
                    { 1, "Paris", "[\"Berlin\",\"Madrid\",\"Paris\",\"Rome\"]", "What is the capital of France?" },
                    { 2, "Mars", "[\"Earth\",\"Mars\",\"Jupiter\",\"Venus\"]", "Which planet is known as the Red Planet?" },
                    { 3, "Pacific Ocean", "[\"Atlantic Ocean\",\"Indian Ocean\",\"Arctic Ocean\",\"Pacific Ocean\"]", "What is the largest ocean on Earth?" },
                    { 4, "William Shakespeare", "[\"William Shakespeare\",\"Charles Dickens\",\"Jane Austen\",\"Mark Twain\"]", "Who wrote the play 'Romeo and Juliet'?" },
                    { 5, "H2O", "[\"H2O\",\"O2\",\"CO2\",\"NaCl\"]", "What is the chemical symbol for water?" },
                    { 6, "Blue Whale", "[\"Elephant\",\"Blue Whale\",\"Giraffe\",\"Hippopotamus\"]", "What is the largest mammal in the world?" },
                    { 7, "Japan", "[\"China\",\"Japan\",\"South Korea\",\"Thailand\"]", "Which country is known as the Land of the Rising Sun?" },
                    { 8, "2", "[\"0\",\"1\",\"2\",\"3\"]", "What is the smallest prime number?" },
                    { 9, "Leonardo da Vinci", "[\"Leonardo da Vinci\",\"Pablo Picasso\",\"Vincent van Gogh\",\"Claude Monet\"]", "Who painted the Mona Lisa?" },
                    { 10, "Dollar", "[\"Euro\",\"Pound\",\"Yen\",\"Dollar\"]", "What is the currency of the United States?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
