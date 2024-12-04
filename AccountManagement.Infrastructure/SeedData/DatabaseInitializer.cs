using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace AccountManagement.Infrastructure.SeedData
{
    public static class DatabaseInitializer
    {
        public static IHost InitializeDatabase(this IHost host)
        {
            ArgumentNullException.ThrowIfNull(host);
            InitializeDatabaseAsync(host).ConfigureAwait(false);

            return host;
        }

        private async static Task InitializeDatabaseAsync(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<IHost>>();
            var dbContext = services.GetRequiredService<UserContext>();
            
            logger.LogDebug("Проверка базы данных на непримененные миграции.");
            if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
            {
                logger.LogDebug("Применение миграций к базе данных.");
                await dbContext.Database.MigrateAsync();
            }
            logger.LogDebug("Проверка завершена.");

            await dbContext.Database.EnsureCreatedAsync();
        }
    }
}
