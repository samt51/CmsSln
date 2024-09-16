using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UserService.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
         //   services.AddDbContext<UserDbContext>(opt =>
         //opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        }
    }
}
