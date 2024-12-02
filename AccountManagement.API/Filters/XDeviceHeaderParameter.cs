using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AccountManagement.API.Filters
{
    /// <summary>
    /// Добавляет выпадающий список для выбора X-Device к методам с атрибутом <see cref="XDeviceFilter"/> в Swagger.
    /// </summary>
    public class XDeviceHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            IEnumerable<object> xDeviceFilterVariants = [typeof(XDeviceFilter),
                typeof(ServiceFilterAttribute<XDeviceFilter>), typeof(TypeFilterAttribute<XDeviceFilter>)];

            var hasXDeviceFilter = context.MethodInfo.GetCustomAttributes(false)
                .Any(attr => xDeviceFilterVariants.Contains(attr.GetType()));

            if (!hasXDeviceFilter) return;

            operation.Parameters.Add(
                new OpenApiParameter
                {
                    Name = "X-Device",
                    In = ParameterLocation.Header,
                    Description = "Header to specify the device type",
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                        Enum = [
                            new OpenApiString("mail"),
                            new OpenApiString("mobile"),
                            new OpenApiString("web"),
                        ]
                    },
                    Required = true,
                }
            );
        }
    }
}
