using Products.Application.Products.Queries.GetProducts;
using Products.Domain.Dtos;

namespace Products.Application.Extensions;

public static class ProductsExtensions
{
    public static GetProductsViewModel ToGetProductsViewModel(ProductsDto productsDto)
    {
        return new GetProductsViewModel
        {
            ProductId = productsDto.ProductId,
            Name = productsDto.Name,
            Description = productsDto.Description,
            Price = productsDto.Price,
            CreatedAt = productsDto.CreatedAt,
            Items = productsDto.Items.Select(productsDto => new GetProductsItemModel
            {
                ItemId = productsDto.ProductId,
                Quantity = productsDto.Quantity,
                ProductId = productsDto.ProductId,
                BatchNumber = productsDto.BatchNumber,

            })

        };
    }
}
