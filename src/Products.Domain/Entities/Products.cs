namespace Products.Domain.Entities;

public class Products
{
    public int ProductId { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public decimal Price { get; init; }
    public DateTime CreatedAt { get; init; }
    public IEnumerable<ProductItem> Items { get; init; } = default!;
}

public class ProductItem
{
    public int ItemId { get; init; }
    public int ProductId { get; init; }
    public int Quantity { get; init; }
    public string BatchNumber { get; init; } = default!;
}
