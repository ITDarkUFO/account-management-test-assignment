using AccountManagement.Application.DTOs;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Interfaces;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Services
{
    public class UserService(IUserRepository repository, IMapper mapper)
    {
        private readonly IUserRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetUserByIdAsync(id);
            return user;
        }

        public async Task<User?> FindUserAsync(FindUserDto userData)
        {
            var user = await _repository.FindUserAsync(userData.FirstName, userData.LastName, userData.MiddleName, userData.PhoneNumber, userData.Email);
            return user;
        }

        public async Task<(bool isValid, List<ValidationResult> errors)> ValidateAndCreateUserAsync(string xDevice, UserCreateDto user)
        {
            object? mappedUser = xDevice switch
            {
                "mail" => _mapper.Map<MailUserCreateDto>(user),
                "mobile" => _mapper.Map<MobileUserCreateDto>(user),
                "web" => _mapper.Map<WebUserCreateDto>(user),
                _ => null
            };

            if (mappedUser == null)
            {
                return (false, [new("Wrond required header: X-Device")]);
            }

            var validationContext = new ValidationContext(mappedUser);
            var validationResults = new List<ValidationResult>();


            if (user.Email != null)
                if (await _repository.FindUserAsync(email: user.Email) != null)
                    validationResults.Add(new("A user with this email already exists.", ["Email"]));

            if (user.PhoneNumber != null)
                if (await _repository.FindUserAsync(phoneNumber: user.PhoneNumber) != null)
                    validationResults.Add(new("A user with this phone number already exists.", ["PhoneNumber"]));

            bool isValid = Validator.TryValidateObject(mappedUser, validationContext, validationResults, true)
                && validationResults.Count == 0;

            if (!isValid)
            {
                return (false, validationResults);
            }

            await _repository.CreateUserAsync(_mapper.Map<User>(user));

            return (true, validationResults);
        }
    }
}
