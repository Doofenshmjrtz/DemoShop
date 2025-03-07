using DemoShop.Api.Filters;
using DemoShop.Application;
using DemoShop.Application.Common.DataAccess;
using DemoShop.Domain.Core;
using FluentValidation;
using MediatR;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IDataAccess, DataAccess>();
builder.Services.AddScoped<ResultFilterAttribute>();
builder.Services.AddMediatR(typeof(DomainEntryPoint).Assembly);
builder.Services.AddMediatR(typeof(ApplicationEntryPoint).Assembly);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ResultFilterAttribute>();
});

builder.Services.Scan(scan => scan
    .FromAssemblyOf<ApplicationEntryPoint>()
    .AddClasses(classes => classes
        .AssignableTo(typeof(IValidator<>)))
    .AsImplementedInterfaces()
    .WithScopedLifetime()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("DemoShop.Api")
            .WithTheme(ScalarTheme.Purple)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.MapControllers(); 

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}