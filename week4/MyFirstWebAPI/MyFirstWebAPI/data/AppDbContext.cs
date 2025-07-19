using Microsoft.EntityFrameworkCore;
using MyFirstWebAPI.model;

namespace MyFirstWebAPI.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
