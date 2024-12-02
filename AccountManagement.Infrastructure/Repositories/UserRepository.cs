using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.Repositories
{
    public class UserRepository(UserContext context) : IUserRepository
    {
        private readonly UserContext _context = context;

        public async Task CreateUserAsync(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User?> FindUserAsync(string? firstName = null, string? lastName = null, string? middleName = null,
            string? phoneNumber = null, string? email = null)
        {
            var query = _context.Users.AsNoTracking();

            if (firstName != null)
                query = query.Where(q => q.FirstName == firstName);

            if (lastName != null)
                query = query.Where(q => q.LastName == lastName);

            if (middleName != null)
                query = query.Where(q => q.MiddleName == middleName);

            if (phoneNumber != null)
                query = query.Where(q => q.PhoneNumber == phoneNumber);

            if (email != null)
                query = query.Where(q => q.Email == email);

            return await query.FirstOrDefaultAsync();
        }
    }
}
