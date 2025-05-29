using Ardalis.Result;
using MediatR;
using Products.Domain.Dtos;

namespace Products.Application.Products.Commands.CreateProducts;

public class CreateProductsCommand : IRequest<Result>
{
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public decimal Price { get; init; }
    public IEnumerable<ProductItemDto> Items { get; init; } = default!;
}