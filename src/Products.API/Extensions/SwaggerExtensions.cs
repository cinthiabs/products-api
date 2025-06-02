using Microsoft.OpenApi.Models;

namespace Products.API.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwaggerUi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen(c =>
        {

            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "products-api",
                Description = "Api responsible for product management.",
                Version = "v1"
            });
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });
    }
}