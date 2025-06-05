using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Products.Application.Products.Commands.CreateProducts;
using Products.Application.Validators;
using System.Reflection;

namespace Products.Application.Extensions;

public static class MediatrExtensions
{
    public static void AddMediatRApi(this IServiceCollection services)
    {
        services.AddMediatR(m => m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(ProductValidator).Assembly);
    }
}
