using Cms.Shared.Abstract.Repository;
using Cms.Shared.Bases.CrossCuttuingConcerns.Middleware.GlobalExceptions;
using Cms.Shared.Concrete.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cms.Shared
{
    public static class Registration
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();


            services.AddTransient<ExceptionMiddleware>();

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<Cms.Shared.Abstract.Mapping.IMapper, Cms.Shared.Concrete.Mapping.Mapper>();


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





            return services;
        }

    }
}
