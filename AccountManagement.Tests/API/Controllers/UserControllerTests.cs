using AccountManagement.API.Controllers;
using AccountManagement.Application.DTOs;
using AccountManagement.Application.Interfaces;
using AccountManagement.Domain.Entities;
using AccountManagement.Tests.Shared;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AccountManagement.Tests.API.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetUserByIdAsyncAndFindUserAsync_ShouldReturnOkResult_WhenUserExists()
        {
            var faker = new Faker();

            // Arrange
            var userController = GetUserServiceWithAnyUser();
            userController.ControllerContext = GetControllerContext();

            // Act
            var userByIdResult = await userController.GetUserByIdAsync(faker.Random.Number(int.MinValue, int.MaxValue));
            var userByValuesResult = await userController.FindUserAsync(TestUserFactory.GetFindUserDto());

            // Assert
            Assert.IsType<OkObjectResult>(userByIdResult);
            Assert.IsType<OkObjectResult>(userByValuesResult);
        }

        [Fact]
        public async Task GetUserByIdAsyncAndFindUserAsync_ShouldReturnNotFound_WhenUserNotExists()
        {
            var faker = new Faker();

            // Arrange
            var userController = GetUserServiceWithoutUsers();
            userController.ControllerContext = GetControllerContext();

            // Act
            var userByIdResult = await userController.GetUserByIdAsync(faker.Random.Number(int.MinValue, int.MaxValue));
            var userByValuesResult = await userController.FindUserAsync(TestUserFactory.GetFindUserDto());

            // Assert
            Assert.IsType<NotFoundResult>(userByIdResult);
            Assert.IsType<NotFoundResult>(userByValuesResult);
        }

        [Fact]
        public async Task CreateUserAsync_ShouldReturnOkResult_WhenUserIsValid()
        {
            // Arrange
            var userController = GetUserServiceWithoutUsers();
            userController.ControllerContext = GetControllerContext();

            // Act
            var result = await userController.CreateUserAsync(TestUserFactory.GetUserCreateDto());

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CreateUserAsync_ShouldReturnNotFound_WhenUserIsNotValid()
        {
            // Arrange
            var userController = GetUserServiceWithAnyUser();
            userController.ControllerContext = GetControllerContext();

            // Act
            var result = await userController.CreateUserAsync(TestUserFactory.GetUserCreateDto());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        private static UserController GetUserServiceWithAnyUser()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetUserByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new User());
            userServiceMock.Setup(service => service.FindUserAsync(It.IsAny<FindUserDto>()))
                .ReturnsAsync(new User());
            userServiceMock.Setup(service => service.ValidateAndCreateUserAsync(It.IsAny<string>(), It.IsAny<UserCreateDto>()))
                .ReturnsAsync((false, [new("UserExistsTestError", ["UserExistsTestErrorMember"])]));

            return new UserController(userServiceMock.Object);
        }

        private static UserController GetUserServiceWithoutUsers()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetUserByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((User?)null);
            userServiceMock.Setup(service => service.FindUserAsync(It.IsAny<FindUserDto>()))
                .ReturnsAsync((User?)null);
            userServiceMock.Setup(service => service.ValidateAndCreateUserAsync(It.IsAny<string>(), It.IsAny<UserCreateDto>()))
                .ReturnsAsync((true, []));

            return new UserController(userServiceMock.Object);
        }

        private static ControllerContext GetControllerContext()
        {
            var faker = new Faker();
            List<string> _acceptableXDevices = ["web", "mail", "mobile"];

            var httpContext = new DefaultHttpContext();
            httpContext.Items["X-Device"] = faker.Random.ListItem(_acceptableXDevices);

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext
            };

            return controllerContext;
        }
    }
}
