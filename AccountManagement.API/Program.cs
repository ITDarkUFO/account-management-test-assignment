using AccountManagement.API.Filters;
using AccountManagement.Application.Interfaces;
using AccountManagement.Application.Services;
using AccountManagement.Domain.Interfaces;
using AccountManagement.Infrastructure;
using AccountManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_ACCOUNTMANAGEMENT_WEB_CONNECTIONSTRING");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException(
        "Строка подключения не найдена. Убедитесь, что переменная окружения 'ASPNETCORE_ACCOUNTMANAGEMENT_WEB_CONNECTIONSTRING' задана.");
}

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers()
    .AddDataAnnotationsLocalization();
builder.Services.AddLocalization();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(AccountManagement.Application.Mapping.MappingProfile));

builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<XDeviceHeaderParameter>();
    options.MapType<DateOnly>(() => new OpenApiSchema 
    {
        Type = "string",
        Format = "date"
    });
});

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<XDeviceHeaderParameter>();
builder.Services.AddScoped<XDeviceFilter>();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
