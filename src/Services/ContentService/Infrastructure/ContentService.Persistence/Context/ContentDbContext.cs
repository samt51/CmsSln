using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ContentService.Persistence.Context
{
    public class ContentDbContext : DbContext
    {

        public ContentDbContext(DbContextOptions<ContentDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        //public DbSet<Content> Contents { get; set; }
    }
}
