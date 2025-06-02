using Ardalis.Result;
using MediatR;

namespace Products.Application.Products.Queries.GetProducts;

public class GetProductsQuery: IRequest<Result<GetProductsViewModel>>;
