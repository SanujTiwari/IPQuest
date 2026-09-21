using IPQuest.Models;
using Microsoft.EntityFrameworkCore;

namespace IPQuest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<AnswerOption> AnswerOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Topic>().HasData(
                new Topic
                {
                    Id = 1,
                    Title = "Copyright",
                    Description = "Protects original creative works such as books, music, videos, and artwork.",
                    Icon = "©"
                },

                new Topic
                {
                    Id = 2,
                    Title = "Trademark",
                    Description = "Protects brand names, logos, symbols, and other identifiers.",
                    Icon = "™"
                },

                new Topic
                {
                    Id = 3,
                    Title = "Patent",
                    Description = "Protects new inventions and innovative technical solutions.",
                    Icon = "⚙"
                },

                new Topic
                {
                    Id = 4,
                    Title = "Trade Secret",
                    Description = "Protects valuable confidential business information and know-how.",
                    Icon = "🔐"
                }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, Text = "Which of these is usually protected by copyright?", TopicId = 1 },
                new Question { Id = 2, Text = "Who generally owns copyright in an original song created by a person?", TopicId = 1 },
                new Question { Id = 3, Text = "Which action may violate copyright?", TopicId = 1 },

                new Question { Id = 4, Text = "What does a trademark mainly help identify?", TopicId = 2 },
                new Question { Id = 5, Text = "Which symbol is commonly associated with an unregistered trademark?", TopicId = 2 },
                new Question { Id = 6, Text = "Which of these can be protected as a trademark?", TopicId = 2 },

                new Question { Id = 7, Text = "What does a patent protect?", TopicId = 3 },
                new Question { Id = 8, Text = "What is an invention generally required to be for patent protection?", TopicId = 3 },
                new Question { Id = 9, Text = "Which of these could potentially be patented?", TopicId = 3 },

                new Question { Id = 10, Text = "What is a trade secret?", TopicId = 4 },
                new Question { Id = 11, Text = "Which of these could be a trade secret?", TopicId = 4 },
                new Question { Id = 12, Text = "What is important for keeping a trade secret protected?", TopicId = 4 }
            );

            modelBuilder.Entity<AnswerOption>().HasData(
                new AnswerOption { Id = 1, Text = "A song", IsCorrect = true, QuestionId = 1 },
                new AnswerOption { Id = 2, Text = "A company logo", IsCorrect = false, QuestionId = 1 },
                new AnswerOption { Id = 3, Text = "A new machine", IsCorrect = false, QuestionId = 1 },
                new AnswerOption { Id = 4, Text = "A secret recipe", IsCorrect = false, QuestionId = 1 },

                new AnswerOption { Id = 5, Text = "The creator", IsCorrect = true, QuestionId = 2 },
                new AnswerOption { Id = 6, Text = "Every person who hears it", IsCorrect = false, QuestionId = 2 },
                new AnswerOption { Id = 7, Text = "The nearest shop", IsCorrect = false, QuestionId = 2 },
                new AnswerOption { Id = 8, Text = "Nobody", IsCorrect = false, QuestionId = 2 },

                new AnswerOption { Id = 9, Text = "Copying a protected work without permission", IsCorrect = true, QuestionId = 3 },
                new AnswerOption { Id = 10, Text = "Creating your own drawing", IsCorrect = false, QuestionId = 3 },
                new AnswerOption { Id = 11, Text = "Writing your own story", IsCorrect = false, QuestionId = 3 },
                new AnswerOption { Id = 12, Text = "Making your own music", IsCorrect = false, QuestionId = 3 },

                new AnswerOption { Id = 13, Text = "A brand or source of goods or services", IsCorrect = true, QuestionId = 4 },
                new AnswerOption { Id = 14, Text = "A secret password", IsCorrect = false, QuestionId = 4 },
                new AnswerOption { Id = 15, Text = "A computer program", IsCorrect = false, QuestionId = 4 },
                new AnswerOption { Id = 16, Text = "A private diary", IsCorrect = false, QuestionId = 4 },

                new AnswerOption { Id = 17, Text = "™", IsCorrect = true, QuestionId = 5 },
                new AnswerOption { Id = 18, Text = "©", IsCorrect = false, QuestionId = 5 },
                new AnswerOption { Id = 19, Text = "₹", IsCorrect = false, QuestionId = 5 },
                new AnswerOption { Id = 20, Text = "#", IsCorrect = false, QuestionId = 5 },

                new AnswerOption { Id = 21, Text = "A brand name or logo", IsCorrect = true, QuestionId = 6 },
                new AnswerOption { Id = 22, Text = "A secret business formula", IsCorrect = false, QuestionId = 6 },
                new AnswerOption { Id = 23, Text = "A scientific discovery", IsCorrect = false, QuestionId = 6 },
                new AnswerOption { Id = 24, Text = "A personal password", IsCorrect = false, QuestionId = 6 },

                new AnswerOption { Id = 25, Text = "An invention", IsCorrect = true, QuestionId = 7 },
                new AnswerOption { Id = 26, Text = "A company slogan only", IsCorrect = false, QuestionId = 7 },
                new AnswerOption { Id = 27, Text = "A person's nickname", IsCorrect = false, QuestionId = 7 },
                new AnswerOption { Id = 28, Text = "A school timetable", IsCorrect = false, QuestionId = 7 },

                new AnswerOption { Id = 29, Text = "New and inventive", IsCorrect = true, QuestionId = 8 },
                new AnswerOption { Id = 30, Text = "Already copied", IsCorrect = false, QuestionId = 8 },
                new AnswerOption { Id = 31, Text = "Kept only in a notebook", IsCorrect = false, QuestionId = 8 },
                new AnswerOption { Id = 32, Text = "A brand name", IsCorrect = false, QuestionId = 8 },

                new AnswerOption { Id = 33, Text = "A new technical device", IsCorrect = true, QuestionId = 9 },
                new AnswerOption { Id = 34, Text = "A common word", IsCorrect = false, QuestionId = 9 },
                new AnswerOption { Id = 35, Text = "A company color alone", IsCorrect = false, QuestionId = 9 },
                new AnswerOption { Id = 36, Text = "A person's signature", IsCorrect = false, QuestionId = 9 },

                new AnswerOption { Id = 37, Text = "Confidential business information with value", IsCorrect = true, QuestionId = 10 },
                new AnswerOption { Id = 38, Text = "A public advertisement", IsCorrect = false, QuestionId = 10 },
                new AnswerOption { Id = 39, Text = "A school uniform", IsCorrect = false, QuestionId = 10 },
                new AnswerOption { Id = 40, Text = "A public website", IsCorrect = false, QuestionId = 10 },

                new AnswerOption { Id = 41, Text = "A secret recipe", IsCorrect = true, QuestionId = 11 },
                new AnswerOption { Id = 42, Text = "A public logo", IsCorrect = false, QuestionId = 11 },
                new AnswerOption { Id = 43, Text = "A published book", IsCorrect = false, QuestionId = 11 },
                new AnswerOption { Id = 44, Text = "A public advertisement", IsCorrect = false, QuestionId = 11 },

                new AnswerOption { Id = 45, Text = "Keeping the information confidential", IsCorrect = true, QuestionId = 12 },
                new AnswerOption { Id = 46, Text = "Publishing it online", IsCorrect = false, QuestionId = 12 },
                new AnswerOption { Id = 47, Text = "Sharing it publicly", IsCorrect = false, QuestionId = 12 },
                new AnswerOption { Id = 48, Text = "Posting it on social media", IsCorrect = false, QuestionId = 12 }
            );
        }
    }
}