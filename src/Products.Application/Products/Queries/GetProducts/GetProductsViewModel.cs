namespace Products.Application.Products.Queries.GetProducts;

public record struct GetProductsViewModel(
    int ProductId,
    string Name,
    string Description,
    decimal Price,
    DateTime CreatedAt,
    IEnumerable<GetProductsItemModel> Items
);

public record struct GetProductsItemModel(
    int ItemId,
    int ProductId,
    int Quantity,
    string BatchNumber
);