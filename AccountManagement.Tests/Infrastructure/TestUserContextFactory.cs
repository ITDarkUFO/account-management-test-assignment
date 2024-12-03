using AccountManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Tests.Infrastructure
{
    public class TestUserContextFactory
    {
        public static async Task<UserContext> GetContextAsync()
        {
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseSqlite("DataSource=:memory:").Options;

            var context = new UserContext(options);
            await context.Database.OpenConnectionAsync();
            await context.Database.EnsureCreatedAsync();

            return context;
        }
    }
}
