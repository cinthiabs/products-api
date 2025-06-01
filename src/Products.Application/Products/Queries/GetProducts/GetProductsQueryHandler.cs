using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Products.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler(ILogger<GetProductsQueryHandler> logger) : IRequestHandler<GetProductsQuery, Result<GetProductsQuery>>
{
    public Task<Result<GetProductsQuery>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}