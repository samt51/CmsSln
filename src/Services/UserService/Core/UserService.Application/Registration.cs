using Cms.Shared.MessageQuery;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using UserService.Application.Consumers;

namespace UserService.Application
{
    public static class Registration
    {

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<UserSelectedConsumer>();
                x.AddConsumer<UserSelectedByIdConsumer>();
                x.AddConsumer<UserUpdatedEventCunsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", 5672, "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                    cfg.ReceiveEndpoint(RabbitMQSettingsConst.UserUpdatedEventQueueName, e =>
                    {
                        e.ConfigureConsumer<UserUpdatedEventCunsumer>(context);
                    });
                    cfg.ReceiveEndpoint(RabbitMQSettingsConst.UserSelectedByIdEventQueueName, e =>
                    {
                        e.ConfigureConsumer<UserSelectedByIdConsumer>(context);
                    });
                    cfg.ReceiveEndpoint(RabbitMQSettingsConst.UserSelectedEventQueueName, e =>
                    {
                        e.ConfigureConsumer<UserSelectedConsumer>(context);
                    });
                });
            });

            services.AddMassTransitHostedService();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));


            services.AddAutoMapper(assembly);



            return services;
        }
    }
}

