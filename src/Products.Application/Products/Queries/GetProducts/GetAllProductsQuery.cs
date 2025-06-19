using Ardalis.Result;
using MediatR;

namespace Products.Application.Products.Queries.GetProducts;

public class GetAllProductsQuery: IRequest<Result<GetAllProductsViewModel>>;
