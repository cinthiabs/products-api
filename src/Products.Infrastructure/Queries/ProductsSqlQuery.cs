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

    internal const string QuerySelectProductsById = @"
        AND ProductId = @Id
    ";

    internal const string QueryUpdateProductsAndItem = @"
        UPDATE Item
        SET Active = 0
        WHERE ProductId = @ProductId;

        UPDATE Product
        SET Active = 0
        WHERE ProductId = @ProductId;
    ";

    internal const string QueryDeleteProductsAndItem = @"
        DELETE FROM Item
        WHERE ProductId = @ProductId;

        DELETE FROM Product
        WHERE ProductId = @ProductId;
    ";
}