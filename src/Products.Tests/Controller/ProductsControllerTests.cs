using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Products.API.Controllers.v1;
using Products.Application.Products.Queries.GetProducts;

namespace Products.Tests.Controller;

public class ProductsControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly ProductsController _controller;
    public ProductsControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new ProductsController();
    }

    [Fact]
    public async Task GetProductsAsync_ReturnsOk_WhenSuccess()
    {
        // Arrange
        var viewModel = new GetAllProductsViewModel { Products = new List<GetProductsViewModel>() };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(Result.Success(viewModel));

        // Act
        var result = await _controller.GetProductsAynsc(_mediatorMock.Object, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsType<GetAllProductsViewModel>(okResult.Value);
    }

}
