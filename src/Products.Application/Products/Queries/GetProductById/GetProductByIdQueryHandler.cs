using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Extensions;
using Products.Domain.Constants;
using Products.Domain.Interfaces.Repositories;

namespace Products.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler(ILogger<GetProductByIdQueryHandler> logger, IProductsRepository productsRepository) : IRequestHandler<GetProductByIdQuery, Result<GetProductByIdViewModel>>
{
    public async Task<Result<GetProductByIdViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var getProduct = await productsRepository.GetProductByIdAsync(request.Id, cancellationToken);
            if (getProduct is null)
                return Result.Invalid(new ValidationError(ErrorsNames.INVALID_PRODUCTS));

            var getItem = await productsRepository.GetProductItemsByIdAsync(getProduct.ProductId, cancellationToken);

            return Result.Success(ProductsExtensions.ToGetProductByIdViewModel(getProduct, getItem));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, Logs.LOG_ERROR, ProcessNames.PROCESS_GET_PRODUCT_BY_ID, ErrorsNames.ERROR_GET_PRODUCTS, ex.Message);
            return Result.CriticalError(ErrorsNames.ERROR_GET_PRODUCTS);
        }
    }
}
