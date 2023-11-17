using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using mvc_app_ef.Models;

namespace mvc_app_ef.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>(entity => 
            {
                entity.ToTable("COURSES", "PUBLIC");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasColumnName("NAME");
                entity.Property(e => e.Duration).HasColumnName("DURATION");
            });
        }
    }
}