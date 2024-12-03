using AccountManagement.API.Filters;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;

namespace AccountManagement.Tests.API.Filters
{
    public class XDeviceFilterTests
    {
        private readonly Mock<ILogger<XDeviceFilter>> _loggerMock;
        private readonly List<string> _acceptableXDevices = ["web", "mail", "mobile"];

        public XDeviceFilterTests()
        {
            _loggerMock = new Mock<ILogger<XDeviceFilter>>();
        }

        [Fact]
        public void OnActionExecuting_ActionResultShouldBeBadRequest_WhenXDeviceIsMissingOrIsNotValid()
        {
            // Arrange
            var xDeviceFilter = new XDeviceFilter(_loggerMock.Object);

            var emptyActionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                ActionDescriptor = new ActionDescriptor(),
                RouteData = new RouteData()
            };

            var emptyActionExecutingContext = new ActionExecutingContext(emptyActionContext, [], new Dictionary<string, object?>(), new object());

            var notValidActionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                ActionDescriptor = new ActionDescriptor(),
                RouteData = new RouteData()
            };

            notValidActionContext.HttpContext.Request.Headers["X-Device"] = "not-valid-x-device";

            var notValidActionExecutingContext = new ActionExecutingContext(notValidActionContext, [], new Dictionary<string, object?>(), new object());

            // Act
            xDeviceFilter.OnActionExecuting(emptyActionExecutingContext);
            xDeviceFilter.OnActionExecuting(notValidActionExecutingContext);

            // Assert
            Assert.IsType<BadRequestObjectResult>(emptyActionExecutingContext.Result);
            Assert.IsType<BadRequestObjectResult>(notValidActionExecutingContext.Result);
        }

        [Fact]
        public void OnActionExecuting_HttpContextItemsShouldContainsXDevice_WhenXDeviceIsValid()
        {
            var faker = new Faker();

            // Arrange
            var xDeviceFilter = new XDeviceFilter(_loggerMock.Object);

            var actionContext = new ActionContext()
            {
                HttpContext = new DefaultHttpContext(),
                ActionDescriptor = new ActionDescriptor(),
                RouteData = new RouteData()
            };

            var xDevice = faker.Random.ListItem(_acceptableXDevices);
            actionContext.HttpContext.Request.Headers["X-Device"] = xDevice;

            var actionExecutingContext = new ActionExecutingContext(actionContext, [], new Dictionary<string, object?>(), new object());

            // Act
            xDeviceFilter.OnActionExecuting(actionExecutingContext);

            // Assert
            Assert.NotNull(actionExecutingContext.HttpContext.Items["X-Device"]);
            Assert.Equal(actionExecutingContext.HttpContext.Items["X-Device"], xDevice);
        }
    }
}
