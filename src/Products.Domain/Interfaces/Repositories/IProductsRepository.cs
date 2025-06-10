using Products.Domain.Dtos;
using Products.Domain.Entities;
namespace Products.Domain.Interfaces.Repositories;

public interface IProductsRepository
{
    public Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken);
    public Task<Product> CreateProductsAsync(CreateProductDto createProductsDto, CancellationToken cancellationToken);
}