using Dapper;
using Microsoft.Data.SqlClient;
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

            var result = new List<ProductItem>();

            if (cancellationToken.IsCancellationRequested)
                return result;

            var connection = (SqlConnection)dbContext.Connection;
            var transaction = (SqlTransaction)dbContext.Transaction;

            const string insertSql = @"
        INSERT INTO ProductItem (ProductId, Quantity, BatchNumber)
        VALUES (@ProductId, @Quantity, @BatchNumber);
    ";

            foreach (var item in itemsDto)
            {
                using var command = new SqlCommand(insertSql, connection, transaction);
                command.Parameters.AddWithValue("@ProductId", productId);
                command.Parameters.AddWithValue("@Quantity", item.Quantity);
                command.Parameters.AddWithValue("@BatchNumber", item.BatchNumber ?? (object)DBNull.Value);

                await command.ExecuteNonQueryAsync(cancellationToken);

                result.Add(new ProductItem
                {
                    ProductId = productId,
                    Quantity = item.Quantity,
                    BatchNumber = item.BatchNumber
                });
            }

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