namespace Products.Infrastructure.Queries;

internal static class ProductsSqlQuery
{
    internal const string QueryInsertProducts = @"
        INSERT INTO Product (Name, Description, Price)
        VALUES (@Name, @Description, @Price)
        
        SELECT SCOPE_IDENTITY() AS ProductId;
    ";

    internal const string QuerySelectProducts = @"
    SELECT * FROM  Product (NOLOCK) WHERE Active = 1
    ";

}