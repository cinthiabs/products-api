namespace Products.Infrastructure.Queries;

internal static class ProductItemsSqlQuery
{
    internal const string QueryInsertProductItems = @"
       INSERT INTO Item (ProductId, Quantity, BatchNumber)
       VALUES (@ProductId, @Quantity, @BatchNumber)
        
       SELECT SCOPE_IDENTITY() AS ItemId;
    ";

    internal const string QuerySelectItems = @"
    SELECT * FROM  Item (NOLOCK) WHERE Active = 1
    ";
}
