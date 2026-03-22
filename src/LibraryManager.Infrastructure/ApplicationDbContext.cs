using LibraryManager.Domain.Entities;
using LibraryManager.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace LibraryManager.Infrastructure
{
    public class ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) 
        : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly);
        }
    }
}
