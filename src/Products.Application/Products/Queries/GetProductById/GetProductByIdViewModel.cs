namespace Products.Application.Products.Queries.GetProductById;

public record struct GetProductByIdViewModel(
    int ProductId,
    string Name,
    string Description,
    decimal Price,
    DateTime CreatedAt,
    IEnumerable<GetProductItemByIdViewModel> Items
);

public record struct GetProductItemByIdViewModel(
    int ItemId,
    int ProductId,
    int Quantity,
    string BatchNumber
);