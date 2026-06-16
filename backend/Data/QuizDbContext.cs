using Microsoft.EntityFrameworkCore;
using backend.Models;
using Newtonsoft.Json;

namespace backend.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the conversion for the Options property to store it as JSON in the database
            modelBuilder.Entity<Question>()
                .Property(q => q.Options)
                .HasConversion(
                    // Serialize the list of options to a JSON string when saving to the database
                    v => JsonConvert.SerializeObject(v),
                    // Deserialize the JSON string back to a list of options when reading from the database
                    v => JsonConvert.DeserializeObject<List<string>>(v) ?? new List<string>()
                );

            // Seed data
            modelBuilder.Entity<Question>().HasData(
                new()
                {
                    Id = 1,
                    QuestionText = "What is the capital of France?",
                    Options = ["Berlin", "Madrid", "Paris", "Rome"],
                    CorrectAnswer = "Paris"
                },
                new()
                {
                    Id = 2,
                    QuestionText = "Which planet is known as the Red Planet?",
                    Options = ["Earth", "Mars", "Jupiter", "Venus"],
                    CorrectAnswer = "Mars"
                },
                new()
                {
                    Id = 3,
                    QuestionText = "What is the largest ocean on Earth?",
                    Options = ["Atlantic Ocean", "Indian Ocean", "Arctic Ocean", "Pacific Ocean"],
                    CorrectAnswer = "Pacific Ocean"
                },
                new()
                {
                    Id = 4,
                    QuestionText = "Who wrote the play 'Romeo and Juliet'?",
                    Options = ["William Shakespeare", "Charles Dickens", "Jane Austen", "Mark Twain"],
                    CorrectAnswer = "William Shakespeare"
                },
                new()
                {
                    Id = 5,
                    QuestionText = "What is the chemical symbol for water?",
                    Options = ["H2O", "O2", "CO2", "NaCl"],
                    CorrectAnswer = "H2O"
                },
                new()
                {
                    Id = 6,
                    QuestionText = "What is the largest mammal in the world?",
                    Options = ["Elephant", "Blue Whale", "Giraffe", "Hippopotamus"],
                    CorrectAnswer = "Blue Whale"

                },
                new()
                {
                    Id = 7,
                    QuestionText = "Which country is known as the Land of the Rising Sun?",
                    Options = ["China", "Japan", "South Korea", "Thailand"],
                    CorrectAnswer = "Japan"
                },
                new()
                {
                    Id = 8,
                    QuestionText = "What is the smallest prime number?",
                    Options = ["0", "1", "2", "3"],
                    CorrectAnswer = "2"
                },
                new()
                {
                    Id = 9,
                    QuestionText = "Who painted the Mona Lisa?",
                    Options = ["Leonardo da Vinci", "Pablo Picasso", "Vincent van Gogh", "Claude Monet"],
                    CorrectAnswer = "Leonardo da Vinci"
                },
                new()
                {
                    Id = 10,
                    QuestionText = "What is the currency of the United States?",
                    Options = ["Euro", "Pound", "Yen", "Dollar"],
                    CorrectAnswer = "Dollar"
                }
            );
        }
    }
}