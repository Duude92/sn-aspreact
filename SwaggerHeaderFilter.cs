using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace sn_aspreact
{
    /// <summary>
    /// Operation filter to add the requirement of the custom header
    /// </summary>

    public class SwaggerHeaderFilter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "MY-HEADER",
                In = ParameterLocation.Header,
                Required = true // set to false if this is optional
            });
        }
    }
}
