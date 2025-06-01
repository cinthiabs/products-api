using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Products.Application.Extensions;

public static class MediatrExtensions
{
    public static void AddMediatRApi(this IServiceCollection services)
    {
        services.AddMediatR(m => m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
