using Cms.Shared.Abstract.Mapping;
using Cms.Shared.Abstract.Repository;
using Cms.Shared.Abstract.UnitOfWorks;
using Cms.Shared.Concrete.Mapping;
using Cms.Shared.Concrete.Repository;
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



            services.AddScoped<IUnitOfWork, ContentService.Persistence.Concrete.UnitOfWorks.UnitOfWork>();

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddSingleton<IMapper, Mapper>();
        }
    }
}
