using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastructure.Repositories
{
    public class UserRepository(UserContext context) : IUserRepository
    {
        private readonly UserContext _context = context;

        public Task<User> CreateUserAsync(User user)
        {

            throw new NotImplementedException();
        }

        public Task<User> FindUserAsync(string? FirstName, string? LastName, string? MiddleName, string? PhoneNumber, string? Email)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}
