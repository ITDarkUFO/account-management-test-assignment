using AccountManagement.Application.DTOs;
using AccountManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Interfaces
{
    public interface IUserService
    {
        public Task<User?> GetUserByIdAsync(int id);

        public Task<User?> FindUserAsync(FindUserDto userData);

        public Task<(bool isValid, List<ValidationResult> errors)> ValidateAndCreateUserAsync(string xDevice, UserCreateDto user);
    }
}
