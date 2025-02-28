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
    }
}