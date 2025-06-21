using Products.Application.Products.Commands.CreateProducts;
using Products.Application.Products.Queries.GetProductById;
using Products.Application.Products.Queries.GetProducts;
using Products.Domain.Dtos;
using Products.Domain.Entities;

namespace Products.Application.Extensions;

public static class ProductsExtensions
{
    public static GetAllProductsViewModel ToGetProductsViewModel(IEnumerable<Product> products)
    {
        var productViewModels = products.Select(product => new GetProductsViewModel(
            ProductId: product.ProductId,
            Name: product.Name,
            Description: product.Description,
            Price: product.Price,
            CreatedAt: product.CreatedAt,
            Items: product.Items.Select(item => new GetProductsItemModel(
                ItemId: item.ItemId,
                ProductId: item.ProductId,
                Quantity: item.Quantity,
                BatchNumber: item.BatchNumber
            ))
        ));

        return new GetAllProductsViewModel(
            Products: productViewModels        
        );
    }
    public static GetProductByIdViewModel ToGetProductByIdViewModel(Product product, IEnumerable<ProductItem> items)
    {
        return new GetProductByIdViewModel
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CreatedAt = product.CreatedAt,
            Items = items.Select(item => new GetProductItemByIdViewModel
            {
                ItemId = item.ItemId,
                Quantity = item.Quantity,
                BatchNumber = item.BatchNumber
            }).ToList()
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
