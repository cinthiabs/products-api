using Ardalis.Result;
using MediatR;

namespace Products.Application.Products.Commands.RemoveProducts;

public class RemoveProductsCommand : IRequest<Result>
{
    public int Id { get; set; }
}
