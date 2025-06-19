namespace Products.Domain.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<ProductItem> Items { get; set; } = Enumerable.Empty<ProductItem>();
}

public class ProductItem
{
    public int ItemId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string BatchNumber { get; set; } = default!;
}
