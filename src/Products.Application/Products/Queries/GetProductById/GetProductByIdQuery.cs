using Ardalis.Result;
using MediatR;

namespace Products.Application.Products.Queries.GetProductById;

public class GetProductByIdQuery: IRequest<Result<GetProductByIdViewModel>>
{
    public int Id { get; set; }
}
