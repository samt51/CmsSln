using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.Repository;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Concrete.Mapping;
using Cms.Shared.Concrete.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.Persistence.Context;

namespace UserService.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UserService.Persistence.Concrete.UnitOfWorks.UnitOfWork>();

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddSingleton<IMapper, Mapper>();




        }
    }
}
