using AccountManagement.Domain.Entities;

namespace AccountManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByIdAsync(int id);

        public Task<User> CreateUserAsync(User user);

        public Task<User?> FindUserAsync(string? FirstName, string? LastName, string? MiddleName, string? PhoneNumber, string? Email);
    }
}
