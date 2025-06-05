using Products.Domain.Dtos;
using Products.Domain.Entities;
namespace Products.Domain.Interfaces.Repositories;

public interface IProductsRepository
{
    public Task<Product> GetProducts();
    public Task CreateProducts(CreateProductDto createProductsDto);
}