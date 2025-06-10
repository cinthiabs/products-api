

using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Interfaces.Base;
using Products.Domain.Interfaces.Repositories;
using Products.Infrastructure.Base;
using Products.Infrastructure.Repositories;

namespace Products.Infrastructure;

public static class DependencyInjectionSetup
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(x => new DbContext(ConfigureConnection()));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddRepository();
    }

    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IProductsRepository, ProductsRepository>();
    }

    private static string ConfigureConnection()
    {
        var conn = Environment.GetEnvironmentVariable("DefaultConnection");
        return conn;
    }


}