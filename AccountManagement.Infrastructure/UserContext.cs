using AccountManagement.Domain.Entities;
using AccountManagement.Infrastructure.SeedData;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure
{
    public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
    {
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(SeedDataProvider.GetSeedUsers());
        }
    }
}
