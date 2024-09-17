using ContentService.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Npgsql;
using Microsoft.Extensions.Hosting;

namespace ContentService.Persistence.Context
{
    public class ContentDbContext : DbContext
    {
        public ContentDbContext(DbContextOptions<ContentDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=1425369As;Database=ContentServiceDb;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Content> Contents { get; set; }
    }
}
