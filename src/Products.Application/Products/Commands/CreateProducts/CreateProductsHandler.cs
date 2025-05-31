using Ardalis.Result;
using MediatR;

namespace Products.Application.Products.Commands.CreateProducts;

public class CreateProductsHandler : IRequestHandler<CreateProductsCommand, Result>
{
    public Task<Result> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
