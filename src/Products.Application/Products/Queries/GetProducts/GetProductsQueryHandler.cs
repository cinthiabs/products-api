using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Products.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler(ILogger<GetProductsQueryHandler> logger) : IRequestHandler<GetProductsQuery, Result<GetProductsViewModel>>
{
    public Task<Result<GetProductsViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var viewModel = new GetProductsViewModel()
        {
            ProductId = 1,
            CreatedAt = DateTime.UtcNow,
            Name = "Test",
            Description = "Description",
            Price = 30,
            Items = new List<GetProductsItemModel>
            {
                new GetProductsItemModel
                {
                     ProductId = 1,
                     BatchNumber = "AE781AED",
                     Quantity = 1
                }
            }
        };

        return Task.FromResult(Result.Success(viewModel));
    }
}