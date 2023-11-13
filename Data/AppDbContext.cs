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



    }
}