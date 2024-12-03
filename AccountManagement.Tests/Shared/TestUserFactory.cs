using AccountManagement.Application.DTOs;
using AccountManagement.Domain.Entities;
using Bogus;

namespace AccountManagement.Tests.Shared
{
    public static class TestUserFactory
    {
        const string PHONE_NUMBER_FORMAT = "7##########";

        public static User GetUser()
        {
            var faker = new Faker();

            return new User()
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                MiddleName = faker.Name.FirstName(),
                PhoneNumber = faker.Phone.PhoneNumber(PHONE_NUMBER_FORMAT),
                Email = faker.Internet.Email(),
                Birthday = DateOnly.FromDateTime(faker.Person.DateOfBirth),
                PassportNumber = $"{faker.Random.Int(1000, 9999)} {faker.Random.Int(100000, 999999)}",
                Address = faker.Address.FullAddress()
            };
        }

        public static UserCreateDto GetUserCreateDto()
        {
            var faker = new Faker();

            return new UserCreateDto()
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                MiddleName = faker.Name.FirstName(),
                PhoneNumber = faker.Phone.PhoneNumber(PHONE_NUMBER_FORMAT),
                Email = faker.Internet.Email(),
                Birthday = DateOnly.FromDateTime(faker.Person.DateOfBirth),
                PassportNumber = $"{faker.Random.Int(1000, 9999)} {faker.Random.Int(100000, 999999)}",
                Address = faker.Address.FullAddress()
            };
        }

        public static FindUserDto GetFindUserDto()
        {
            var faker = new Faker();

            return new FindUserDto()
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                MiddleName = faker.Name.FirstName(),
                PhoneNumber = faker.Phone.PhoneNumber(PHONE_NUMBER_FORMAT),
                Email = faker.Internet.Email()
            };
        }
    }
}
