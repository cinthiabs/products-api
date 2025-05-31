using Ardalis.Result;
using MediatR;

namespace Products.Application.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<GetProductsQuery>>
{
    public Task<Result<GetProductsQuery>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}