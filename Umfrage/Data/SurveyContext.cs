using Microsoft.EntityFrameworkCore;
using Umfrage.Model;

namespace Umfrage.Data
{
    public class SurveyContext : DbContext
    {

        public SurveyContext(DbContextOptions<SurveyContext> options)
        : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<UserQuestions> UserQuestions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserQuestions>()
            .HasKey(ep => new { ep.UserId, ep.QuestionsId});


            modelBuilder.Entity<UserQuestions>()
            .HasOne(ep => ep.User)
            .WithMany(e => e.UserQuestions)
            .HasForeignKey(ep => ep.UserId);

            modelBuilder.Entity<UserQuestions>()
            .HasOne(ep => ep.Questions)
            .WithMany(e => e.UserQuestions)
            .HasForeignKey(ep => ep.QuestionsId);
        }
    }
}
