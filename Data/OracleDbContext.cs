using Microsoft.EntityFrameworkCore;
using mvc_app_ef.Models;

namespace mvc_app_ef.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT", "TARJETA");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Lastname).HasColumnName("LASTNAME");
                entity.Property(e => e.Firstmidname).HasColumnName("FIRSTMIDNAME");
                entity.Property(e => e.Enrollmentdate).HasColumnName("ENROLLMENTDATE");
            });
        }
    }
}