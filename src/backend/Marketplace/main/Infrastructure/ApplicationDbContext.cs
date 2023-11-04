using Marketplace.main.Domain;

using Microsoft.EntityFrameworkCore;

namespace Marketplace.main.Infrastructure
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                const string connectionString = "Host=localhost; Database=marketplace_db; Port=15432; Username=admin; Password=test123";
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        public DbSet<Product> Products { get; set; }
    }
}