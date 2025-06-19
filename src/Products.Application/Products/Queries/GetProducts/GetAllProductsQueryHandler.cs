using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Extensions;
using Products.Domain.Constants;
using Products.Domain.Interfaces.Repositories;

namespace Products.Application.Products.Queries.GetProducts;

public class GetAllProductsQueryHandler(ILogger<GetAllProductsQueryHandler> logger, IProductsRepository productsRepository) : IRequestHandler<GetAllProductsQuery, Result<GetAllProductsViewModel>>
{
    public async Task<Result<GetAllProductsViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var products = await productsRepository.GetProductsAsync(cancellationToken);
            return Result.Success(ProductsExtensions.ToGetProductsViewModel(products));

        }
        catch (Exception ex)
        {
            return Result.CriticalError(ProcessNames.PROCESS_GET_PRODUCTS);
        }
    }
}