using DemoShop.Api.Filters;
using DemoShop.Application;
using DemoShop.Application.Common.DataAccess;
using DemoShop.Domain.Core;
using DemoShop.Infrastructure;
using DemoShop.Infrastructure.Contracts;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

// Configure DbContext
builder.Services.AddDbContext<DemoShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Unit of Work and Repositories   
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

app.Run();