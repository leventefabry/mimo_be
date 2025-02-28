using Microsoft.EntityFrameworkCore;
using Mimo.Domain.Entities;

namespace Mimo.Persistence.Data
{
    public class MimoDbContext(DbContextOptions<MimoDbContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Chapter> Chapters { get; set; }

        public DbSet<Lesson> Lessons { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Achievement> Achievements { get; set; }
        
        public DbSet<UserAchievement> UserAchievements { get; set; }
        
        public DbSet<UserLessonProgress> UserLessonProgresses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Achievement>()
                .Property(a => a.AchievementType)
                .HasConversion<string>();
            
            modelBuilder.Entity<Achievement>()
                .HasMany(a => a.Users)
                .WithMany(u => u.Achievements)
                .UsingEntity<UserAchievement>();
            
            modelBuilder.Entity<User>()
                .HasMany(u => u.Lessons)
                .WithMany(l => l.Users)
                .UsingEntity<UserLessonProgress>();
        }
    }
}