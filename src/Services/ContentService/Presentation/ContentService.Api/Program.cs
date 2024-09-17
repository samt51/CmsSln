using ContentService.Persistence;
using Cms.Shared;
using ContentService.Application;
using Microsoft.EntityFrameworkCore;
using ContentService.Persistence.Context;
using Cms.Shared.Bases.CrossCuttuingConcerns.Middleware.GlobalExceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddShared();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);


builder.Services.AddDbContext<ContentDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.ConfigureExceptionHandlingMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
