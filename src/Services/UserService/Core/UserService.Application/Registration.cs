using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UserService.Application
{
    public static class Registration
    {

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", 5672, "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                });
            });

            services.AddMassTransitHostedService();
            // MediatR konfigürasyonu
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            // AutoMapper yapılandırması
            services.AddAutoMapper(assembly);

            // Diğer servis kayıtları

            return services;
        }
    }
}

