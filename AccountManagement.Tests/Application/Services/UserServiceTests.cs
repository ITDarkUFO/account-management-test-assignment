using AccountManagement.Application.DTOs;
using AccountManagement.Application.Mapping;
using AccountManagement.Application.Services;
using AccountManagement.Domain.Entities;
using AccountManagement.Domain.Interfaces;
using AccountManagement.Tests.Shared;
using AutoMapper;
using Bogus;
using Moq;

namespace AccountManagement.Tests.Application.Services
{
    public class UserServiceTests
    {
        private readonly IMapper _mapper;
        const string PHONE_NUMBER_FORMAT = "7##########";

        public UserServiceTests()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = new Mapper(configuration);
        }

        [Fact]
        public async Task GetUserByIdAsyncAndFindUserAsync_ShouldReturnUser_WhenUserExists()
        {
            var faker = new Faker();

            // Arrange
            var userService = GetUserServiceWithAnyUser();

            // Act
            var userById = await userService.GetUserByIdAsync(faker.Random.Number(int.MinValue, int.MaxValue));
            var userByValues = await userService.FindUserAsync(TestUserFactory.GetFindUserDto());

            // Assert
            Assert.NotNull(userById);
            Assert.NotNull(userByValues);
        }

        [Fact]
        public async Task GetUserByIdAsyncAndFindUserAsync_ShouldReturnNull_WhenUserNotExists()
        {
            var faker = new Faker();

            // Arrange
            var userService = GetUserServiceWithoutUsers();

            // Act
            var userById = await userService.GetUserByIdAsync(faker.Random.Number(int.MinValue, int.MaxValue));
            var userByValues = await userService.FindUserAsync(TestUserFactory.GetFindUserDto());

            // Assert
            Assert.Null(userById);
            Assert.Null(userByValues);
        }

        [Fact]
        public async Task ValidateAndCreateUserAsync_ShouldReturnTrue_WhenUserIsValid()
        {
            // Arrange
            var userService = GetUserServiceWithoutUsers();
            var user = TestUserFactory.GetUserCreateDto();

            // Act
            (var mailResult, _) = await userService.ValidateAndCreateUserAsync("mail", user);
            (var mobileResult, _) = await userService.ValidateAndCreateUserAsync("mobile", user);
            (var webResult, _) = await userService.ValidateAndCreateUserAsync("web", user);

            // Assert
            Assert.True(mailResult);
            Assert.True(mobileResult);
            Assert.True(webResult);
        }

        [Fact]
        public async Task ValidateAndCreateUserAsync_ShouldReturnFalse_WhenUserIsNotValid()
        {
            const string WRONG_PASPORT_NUMBER = "0000 0000";
            const string WRONG_PHONE_NUMBER = "70000000";
            const string WRONG_EMAIL = "invalid.email@domain";

            var faker = new Faker();

            // Arrange
            var userService = GetUserServiceWithAnyUser();
            var existingUser = TestUserFactory.GetUserCreateDto();
            var userWithWrongPassportNumber = new UserCreateDto() { PassportNumber = WRONG_PASPORT_NUMBER, PhoneNumber = faker.Phone.PhoneNumber(PHONE_NUMBER_FORMAT) };
            var userWithWrongPhoneNumber = new UserCreateDto() { PhoneNumber = WRONG_PHONE_NUMBER };
            var userWithWrondEmail = new UserCreateDto() { Email = WRONG_EMAIL, PhoneNumber = faker.Phone.PhoneNumber(PHONE_NUMBER_FORMAT) };

            // Act
            (var mailResult, _) = await userService.ValidateAndCreateUserAsync("mail", existingUser);
            (var mobileResult, _) = await userService.ValidateAndCreateUserAsync("mobile", existingUser);
            (var webResult, _) = await userService.ValidateAndCreateUserAsync("web", existingUser);

            (var wrongPassportResult, _) = await userService.ValidateAndCreateUserAsync("mobile", userWithWrongPassportNumber);
            (var wrongPhoneNumberResult, _) = await userService.ValidateAndCreateUserAsync("mobile", userWithWrongPhoneNumber);
            (var wrondEmailResult, _) = await userService.ValidateAndCreateUserAsync("mobile", userWithWrondEmail);

            // Assert
            Assert.False(mailResult);
            Assert.False(mobileResult);
            Assert.False(webResult);

            Assert.False(wrongPassportResult);
            Assert.False(wrongPhoneNumberResult);
            Assert.False(wrondEmailResult);
        }

        private UserService GetUserServiceWithAnyUser()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.CreateUserAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            userRepositoryMock.Setup(repo => repo.GetUserByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new User());

            userRepositoryMock.Setup(repo => repo.FindUserAsync(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string>(), It.IsAny<string?>()))
                .ReturnsAsync(new User());

            var userService = new UserService(userRepositoryMock.Object, _mapper);

            return userService;
        }

        private UserService GetUserServiceWithoutUsers()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.CreateUserAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            userRepositoryMock.Setup(repo => repo.GetUserByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((User?)null);

            userRepositoryMock.Setup(repo => repo.FindUserAsync(It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string?>(), It.IsAny<string>(), It.IsAny<string?>()))
                .ReturnsAsync((User?)null);

            var userService = new UserService(userRepositoryMock.Object, _mapper);

            return userService;
        }
    }
}
