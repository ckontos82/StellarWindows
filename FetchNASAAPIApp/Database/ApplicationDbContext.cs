using FetchNASAAPIApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FetchNASAAPIApp.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Picture> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Picture>()
            .HasIndex(p => p.Date) // Specifies the property to index
            .IsUnique(); // Enforces that the index is unique
        }
    }
}
