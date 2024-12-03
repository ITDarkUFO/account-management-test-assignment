using AccountManagement.Domain.Entities;
using AccountManagement.Infrastructure;
using AccountManagement.Infrastructure.Repositories;
using AccountManagement.Tests.Shared;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Tests.Infrastructure.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task CreateUserAsync_ShouldAddUserToDatabase()
        {
            var faker = new Faker();

            // Arrange
            using var context = await TestUserContextFactory.GetContextAsync();
            var repo = new UserRepository(context);

            var user = TestUserFactory.GetUser();

            // Act
            await repo.CreateUserAsync(user);
            await context.SaveChangesAsync();

            // Assert
            var dbUser = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            Assert.NotNull(dbUser);
            Assert.Equal(dbUser, user);
        }

        [Fact]
        public async Task GetUserByIdAsyncAndFindUserAsync_ShouldReturnUser_WhenUserExists()
        {
            // Arrange
            using var context = await TestUserContextFactory.GetContextAsync();
            var repo = new UserRepository(context);
            var user = await CreateTestUserAsync(context);

            // Act
            var foundUserByID = await repo.GetUserByIdAsync(user.Id);
            var foundUserByValues = await repo.FindUserAsync(user.FirstName, user.LastName, user.MiddleName, user.PhoneNumber, user.Email);

            // Assert
            Assert.NotNull(foundUserByID);
            Assert.Equal(foundUserByID.FirstName, user.FirstName);
            Assert.Equal(foundUserByID.LastName, user.LastName);
            Assert.Equal(foundUserByID.MiddleName, user.MiddleName);
            Assert.Equal(foundUserByID.PhoneNumber, user.PhoneNumber);
            Assert.Equal(foundUserByID.Email, user.Email);

            Assert.NotNull(foundUserByValues);
        }

        [Fact]
        public async Task GetUserByIdAsyncAndFindUserAsync_ShouldReturnNull_WhenUserNotExists()
        {
            var faker = new Faker();

            // Arrange
            using var context = await TestUserContextFactory.GetContextAsync();
            var repo = new UserRepository(context);

            // Act
            var nonExistentUserById = await repo.GetUserByIdAsync(faker.Random.Number(int.MinValue, int.MaxValue));
            var nonExistentUserByValues = await repo.FindUserAsync(faker.Name.FirstName());

            // Assert
            Assert.Null(nonExistentUserById);
            Assert.Null(nonExistentUserByValues);
        }

        private static async Task<User> CreateTestUserAsync(UserContext context)
        {
            var repo = new UserRepository(context);
            var user = TestUserFactory.GetUser();

            await repo.CreateUserAsync(user);
            await context.SaveChangesAsync();

            return user;
        }
    }
}
