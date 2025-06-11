namespace Products.Domain.Dtos;

public class CreateProductDto
{
    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public decimal Price { get; init; }
    public IEnumerable<CreateProductItemDto> Items { get; init; } = default!;
}

public class CreateProductItemDto
{
    public int ProductId { get; init; }
    public int Quantity { get; init; }
    public string BatchNumber { get; init; } = default!;
}