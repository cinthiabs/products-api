using ConfigCat.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Domain.Interfaces.Base;
using Products.Domain.Interfaces.RemoteConfig;
using Products.Domain.Interfaces.Repositories;
using Products.Domain.Interfaces.Services;
using Products.Infrastructure.Base;
using Products.Infrastructure.RemoteConfig;
using Products.Infrastructure.RemoteConfig.ConfigCat;
using Products.Infrastructure.Repositories;
using Products.Infrastructure.Services;

namespace Products.Infrastructure;

public static class DependencyInjectionSetup
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(x => new DbContext(ConfigureConnection()));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddService();
        services.AddRepository();
        services.AddRemoteConfigSetup(configuration);
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

    public static void AddRemoteConfigSetup(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConfigCatRemoteConfig>(x =>
         new ConfigCatRemoteConfig(ConfigCatClient.Get(configuration["CONFIGCAT_CLIENT_TOKEN"]!, options =>
         {
             options.PollingMode = PollingModes.LazyLoad(cacheTimeToLive: TimeSpan.FromMinutes(int.Parse(configuration["CONFIGCAT_TIME_CACHE"]!)));
         })));

        services.AddScoped<IFeatureToggleService, FeatureToggleService>();
    }

}