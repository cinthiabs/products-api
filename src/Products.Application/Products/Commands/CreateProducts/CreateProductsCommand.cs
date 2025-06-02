using Ardalis.Result;
using MediatR;

namespace Products.Application.Products.Commands.CreateProducts;

public class CreateProductsCommand : IRequest<Result>
{
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public decimal Price { get; init; }
    public IEnumerable<CreateProductItemCommand> Items { get; init; } = default!;
}

public class CreateProductItemCommand
{
    public int Quantity { get; init; }
    public string BatchNumber { get; init; } = default!;
}