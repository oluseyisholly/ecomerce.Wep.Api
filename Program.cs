using System.Text;
using AutoMapper;
using EcommerceWebApi.AutoMapper;
using EcommerceWebApi.Common.Model;
using EcommerceWebApi.Data;
using EcommerceWebApi.Extensions;
using EcommerceWebApi.IRepository;
using EcommerceWebApi.IService;
using EcommerceWebApi.Middleware;
using EcommerceWebApi.Repository;
using EcommerceWebApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettings);

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddJwtAuthentication(builder.Configuration, jwtSettings);

// builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(Profile));

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

// Map controller routes
app.MapControllers();

// app.MapGet(
//         "/weatherforecast",
//         () =>
//         {
//             var forecast = Enumerable
//                 .Range(1, 5)
//                 .Select(index => new WeatherForecast(
//                     DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                     Random.Shared.Next(-20, 55),
//                     summaries[Random.Shared.Next(summaries.Length)]
//                 ))
//                 .ToArray();
//             return forecast;
//         }
//     )
//     .WithName("GetWeatherForecast");

app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
