using Dapper;
using Products.Domain.Dtos;
using Products.Domain.Entities;
using Products.Domain.Interfaces.Repositories;
using Products.Infrastructure.Base;
using Products.Infrastructure.Queries;
using Products.Infrastructure.Scripts.Tables;
using SqlBulkHelpers;
using System.Data;

namespace Products.Infrastructure.Repositories;

public class ProductsRepository(DbContext dbContext) : IProductsRepository
{
    private readonly DbContext dbContext = dbContext;

    public async Task<List<ProductItem>> CreateItemsAsync(IEnumerable<CreateProductItemDto> itemsDto, int productId, CancellationToken cancellationToken)
    {
        try
        {
            if (cancellationToken.IsCancellationRequested)
                return new List<ProductItem>();

            var table = itemsDto.Select(item => new Table_Item
            {
                ProductId = productId,
                Quantity = item.Quantity,
                BatchNumber = item.BatchNumber
            }).ToList();

            var insertedItems = await dbContext.Transaction.BulkInsertAsync(table, tableName: ProductItensSqlQuery.TableNameItem);

            var result = insertedItems.Select(item => new ProductItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                BatchNumber = item.BatchNumber
            }).ToList();

            return result;
        }
        catch (Exception ex) 
        {
            throw;
        }
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
        return await dbContext.Connection.QueryAsync<Product>(
            new CommandDefinition(
                ProductsSqlQuery.QuerySelectProducts,
                cancellationToken: cancellationToken));
    }
}