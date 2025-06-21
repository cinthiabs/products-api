using Ardalis.Result;
using Products.Domain.Dtos;

namespace Products.Domain.Interfaces.Services;

public interface IProductsService
{
    public Task<Result> CreateProductsAsync(CreateProductDto createProductsDto, CancellationToken cancellationToken);
    public Task<Result<bool>> RemoveProductsAsync(int idProduct, bool remove, CancellationToken cancellationToken);
}