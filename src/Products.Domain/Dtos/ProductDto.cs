namespace Products.Domain.Dtos;

public class ProductDto
{
    public int ProductId { get; init; }
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public decimal Price { get; init; }
    public DateTime CreatedAt { get; init; }
    public IEnumerable<ProductItemDto> Items { get; init; } = default!;
}

public class ProductItemDto
{
    public int ItemId { get; init; }
    public int ProductId { get; init; }
    public int Quantity { get; init; }
    public string BatchNumber { get; init; } = default!;
}
