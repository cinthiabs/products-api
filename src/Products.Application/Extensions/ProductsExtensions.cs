using Products.Application.Products.Commands.CreateProducts;
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

    public static CreateProductDto ToCreateProductsDto(CreateProductsCommand createProductsCommand)
    {
        return new CreateProductDto
        {
            Name = createProductsCommand.Name,
            Description = createProductsCommand.Description,
            Price = createProductsCommand.Price,
            Items = createProductsCommand.Items.Select(createProductsCommand => new CreateProductItemDto
            {
                Quantity = createProductsCommand.Quantity,
                BatchNumber = createProductsCommand.BatchNumber
            })
        };
    }
}
