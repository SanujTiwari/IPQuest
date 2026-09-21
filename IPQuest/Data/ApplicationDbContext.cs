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
        }
    }
}