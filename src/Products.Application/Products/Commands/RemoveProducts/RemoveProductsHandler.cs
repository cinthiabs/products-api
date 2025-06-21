using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Products.Commands.CreateProducts;
using Products.Domain.Constants;
using Products.Domain.Interfaces.RemoteConfig;
using Products.Domain.Interfaces.Services;

namespace Products.Application.Products.Commands.RemoveProducts;

public class RemoveProductsHandler(ILogger<RemoveProductsHandler> logger, IFeatureToggleService featureToggleService, IProductsService productsService) : IRequestHandler<RemoveProductsCommand, Result>
{
    public async Task<Result> Handle(RemoveProductsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var getRule = await featureToggleService.GetRuleDeleteProduct(cancellationToken);

            var removeProducts = await productsService.RemoveProductsAsync(request.Id, getRule, cancellationToken);
            if (removeProducts.IsInvalid())
                return Result.Invalid(new ValidationError(ErrorsNames.INVALID_PRODUCTS));

            if (!removeProducts.IsSuccess)
                return Result.Error(ErrorsNames.ERROR_REMOVE_PRODUCT);

            return Result.Success();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, Logs.LOG_ERROR, ProcessNames.PROCESS_REMOVE_PRODUCT, ErrorsNames.ERROR_CREATE_PRODUCT, ex.Message);
            return Result.CriticalError(ErrorsNames.ERROR_REMOVE_PRODUCT);
        }

    }
}