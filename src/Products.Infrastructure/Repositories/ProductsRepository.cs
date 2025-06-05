using Products.Domain.Dtos;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repositories;

namespace Products.Infrastructure.Repositories;

public class ProductsRepository : IProductsRepository
{
    public Task CreateProducts(CreateProductDto createProductsDto)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProducts()
    {
        throw new NotImplementedException();
    }
}
