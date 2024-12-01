using AccountManagement.Domain.Interfaces;
using AccountManagement.Infrastructure;
using AccountManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var connectionString = Environment.GetEnvironmentVariable("ASPNETCORE_ACCOUNTMANAGEMENT_WEB_CONNECTIONSTRING");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException(
        "Строка подключения не найдена. Убедитесь, что переменная окружения 'ASPNETCORE_ACCOUNTMANAGEMENT_WEB_CONNECTIONSTRING' задана.");
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddControllers()
    .AddDataAnnotationsLocalization();
builder.Services.AddLocalization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();

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
