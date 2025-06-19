using Ardalis.Result;
using Products.Domain.Dtos;

namespace Products.Domain.Interfaces.Services;

public interface IProductsService
{
    public Task<Result> CreateProductsAsync(CreateProductDto createProductsDto, CancellationToken cancellationToken);
}