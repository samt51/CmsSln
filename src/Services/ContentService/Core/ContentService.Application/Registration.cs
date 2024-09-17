using Cms.Shared.MessageQuery;
using ContentService.Application.Consumers;
using ContentService.Application.Feature.Contents.Commands.UpdateUser;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ContentService.Application
{
    public static class Registration
    {

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<UserUpdatedCompletedEventConsumer>();
                x.AddConsumer<UserUpdatedFailedEventConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", 5672, "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ReceiveEndpoint(RabbitMQSettingsConst.UserUpdatedCompletedEventQueueName, e =>
                    {
                        e.ConfigureConsumer<UserUpdatedCompletedEventConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(RabbitMQSettingsConst.UserUpdatedFailedEventQueueName, e =>
                    {
                        e.ConfigureConsumer<UserUpdatedFailedEventConsumer>(context);
                    });

                });
            });

            services.AddMassTransitHostedService();
            services.AddScoped<UpdateUserCommandHandler>();

            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
