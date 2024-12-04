using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AccountManagement.API.Filters
{
    /// <summary>
    /// Фильтр для методов контроллеров, проверяющий наличие заголовка X-Device в запросе.<br/>
    /// Если заголовок отсутствует или содержит недопустимое значение, запрос отклоняется.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class XDeviceFilter(ILogger<XDeviceFilter> logger) : Attribute, IActionFilter
    {
        private readonly ILogger<XDeviceFilter> _logger = logger;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("X-Device", out var xDeviceValues))
            {
                _logger.LogWarning("X-Device header is missing");
                context.Result = new BadRequestObjectResult("Missing required header: X-Device");
                return;
            }

            var xDevice = xDeviceValues.First()!.ToString().ToLowerInvariant();

            switch (xDevice)
            {
                case "mail":
                case "mobile":
                case "web":
                    context.HttpContext.Items.TryAdd("X-Device", xDevice);
                    break;

                default:
                    _logger.LogWarning("Wrong X-Device header");
                    context.Result = new BadRequestObjectResult("Wrong required header: X-Device");
                    break;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
