using Products.Application.Products.Queries.GetProductById;

namespace Products.Tests.Fixtures;

public static class ProductsFixtures
{
    public static GetProductByIdViewModel GetProductByIdViewModel()
    {
        return new GetProductByIdViewModel
        {
            ProductId = 1,
            Name = "Product 1",
            Description = "Description",
            Price = 3,
            Items = new List<GetProductItemByIdViewModel>
            {
                new GetProductItemByIdViewModel()
                {
                    ProductId = 1,
                    ItemId = 1,
                    BatchNumber = "345545",
                    Quantity = 2

                }
            }
        };
    }
}
