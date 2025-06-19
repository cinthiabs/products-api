using Dapper;
using Products.Domain.Dtos;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repositories;
using Products.Infrastructure.Base;
using Products.Infrastructure.Queries;
using System.Data;

namespace Products.Infrastructure.Repositories;

public class ProductsRepository(DbContext dbContext) : IProductsRepository
{
    private readonly DbContext dbContext = dbContext;

    public async Task<List<ProductItem>> CreateItemsAsync(IEnumerable<CreateProductItemDto> itemsDto, int productId, CancellationToken cancellationToken)
    {
            var result = new List<ProductItem>();

            if (cancellationToken.IsCancellationRequested)
                return result;

            foreach (var item in itemsDto)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ProductId", productId, DbType.Int64);
                parameters.Add("@Quantity", item.Quantity, DbType.Int64);
                parameters.Add("@BatchNumber", item.BatchNumber, DbType.String);

              var productItem =  await dbContext.Connection.ExecuteScalarAsync<int>(
              new CommandDefinition(
                  ProductItemsSqlQuery.QueryInsertProductItems,
                  parameters,
                  dbContext.Transaction,
                  cancellationToken: cancellationToken));

                result.Add(new ProductItem
                {
                    ItemId = productItem,
                    ProductId = productId,
                    Quantity = item.Quantity,
                    BatchNumber = item.BatchNumber
                });
            }
       
        return result;      
    }

    public async Task<Product> CreateProductsAsync(CreateProductDto createProductsDto, CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Name", createProductsDto.Name, DbType.String);
        parameters.Add("@Description", createProductsDto.Description, DbType.String);
        parameters.Add("@Price", createProductsDto.Price, DbType.Decimal);

        var productId = await dbContext.Connection.ExecuteScalarAsync<int>(
            new CommandDefinition(
                ProductsSqlQuery.QueryInsertProducts,
                parameters,
                dbContext.Transaction,
                cancellationToken: cancellationToken));

        return new Product
        {
            ProductId = productId,
            Name = createProductsDto.Name,
            Description = createProductsDto.Description,
            Price = createProductsDto.Price
        };
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken)
    {
        var products = (await dbContext.Connection.QueryAsync<Product>(
            new CommandDefinition(
                ProductsSqlQuery.QuerySelectProducts,
                cancellationToken: cancellationToken))).ToList();

        var items = (await dbContext.Connection.QueryAsync<ProductItem>(
             new CommandDefinition(
                 ProductItemsSqlQuery.QuerySelectItems,
                 cancellationToken: cancellationToken))).ToList();

        var itemsByProductId = items.GroupBy(i => i.ProductId)
                                .ToDictionary(g => g.Key, g => g.AsEnumerable());

        foreach (var product in products)
        {
            if (itemsByProductId.TryGetValue(product.ProductId, out var productItems))
            {
                product.Items = productItems;
            }
            else
            {
                product.Items = Enumerable.Empty<ProductItem>();
            }
        }

        return products;
    }
}