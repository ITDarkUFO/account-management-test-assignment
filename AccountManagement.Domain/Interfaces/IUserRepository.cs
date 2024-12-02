using AccountManagement.Domain.Entities;

namespace AccountManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByIdAsync(int id);

        public Task<User?> FindUserAsync(string? firstName = null, string? lastName = null, string? middleName = null, 
            string? phoneNumber = null, string? email = null);

        public Task CreateUserAsync(User user);
    }
}
