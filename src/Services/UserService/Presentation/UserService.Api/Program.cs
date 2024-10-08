using Cms.Shared;
using UserService.Persistence;
using UserService.Application;
using Microsoft.EntityFrameworkCore;
using UserService.Persistence.Context;
using Cms.Shared.Bases.CrossCuttuingConcerns.Middleware.GlobalExceptions;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddShared();
        builder.Services.AddPersistence(builder.Configuration);
        builder.Services.AddApplication(builder.Configuration);

        builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.ConfigureExceptionHandlingMiddleware();
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}