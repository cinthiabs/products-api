using Products.Domain.Dtos;
using Products.Domain.Entities;
namespace Products.Domain.Interfaces.Repositories;

public interface IProductsRepository
{
    public Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken);
    public Task<Product> CreateProductsAsync(CreateProductDto createProductsDto, CancellationToken cancellationToken);
    public Task<List<ProductItem>> CreateItemsAsync(IEnumerable<CreateProductItemDto> itemsDto, int productId, CancellationToken cancellationToken);
    public Task<Product> GetProductByIdAsync(int id, CancellationToken cancellationToken);
    public Task<IEnumerable<ProductItem>> GetProductItemsByIdAsync(int productId, CancellationToken cancellationToken);
    public Task<bool> RemoveProductsAsync(int productId, CancellationToken cancellationToken);
    public Task<bool> InactiveProductsAsync(int productId, CancellationToken cancellationToken);
}