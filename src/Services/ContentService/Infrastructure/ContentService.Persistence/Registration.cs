using ContentService.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContentService.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContentDbContext>(opt =>
         opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        }
    }
}
