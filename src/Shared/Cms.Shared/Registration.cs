using Cms.Shared.Abstract.Repositories;
using Cms.Shared.Abstract.UnitOfWork;
using Cms.Shared.Bases;
using Cms.Shared.Concrete.Repositories;
using Cms.Shared.Concrete.UnitOfWorks;
using Cms.Shared.Middleware.GlobalExceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cms.Shared
{
    public static class Registration
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddTransient<ExceptionMiddleware>();


            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
        private static IServiceCollection AddRulesFromAssemblyContaining(
           this IServiceCollection services,
           Assembly assembly,
           Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                services.AddTransient(item);

            return services;
        }
    }
}
