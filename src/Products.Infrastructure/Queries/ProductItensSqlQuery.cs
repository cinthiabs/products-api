namespace Products.Infrastructure.Queries;

internal static class ProductItensSqlQuery
{
    internal const string TableNameItem = "Item";

    internal const string QueryInsertProductItens = @"
       INSERT INTO Item (ProductId, Quantity, BatchNumber)
       VALUES (@ProductId, @Quantity, @BatchNumber)
        
       SELECT SCOPE_IDENTITY() AS ItemId;
    ";
}
