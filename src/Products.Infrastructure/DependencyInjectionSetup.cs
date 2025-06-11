

using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Interfaces.Base;
using Products.Domain.Interfaces.Repositories;
using Products.Domain.Interfaces.Services;
using Products.Infrastructure.Base;
using Products.Infrastructure.Repositories;
using Products.Infrastructure.Services;

namespace Products.Infrastructure;

public static class DependencyInjectionSetup
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(x => new DbContext(ConfigureConnection()));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddService();
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

    public static void AddService(this IServiceCollection services)
    {
        services.AddScoped<IProductsService, ProductsService>();
    }


}