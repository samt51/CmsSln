using ContentService.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ContentService.Persistence.Context
{
    public class ContentDbContext : DbContext
    {

        public ContentDbContext(DbContextOptions<ContentDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DESKTOP-L558L50\\LOCALSQL,1434;Database=ContentServiceDb;Trusted_Connection=True;TrustServerCertificate=true;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Content> Contents { get; set; }
    }
}
