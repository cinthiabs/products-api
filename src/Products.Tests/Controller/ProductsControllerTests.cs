using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Products.API.Controllers.v1;
using Products.Application.Products.Commands.CreateProducts;
using Products.Application.Products.Commands.RemoveProducts;
using Products.Application.Products.Queries.GetProductById;
using Products.Application.Products.Queries.GetProducts;
using Products.Domain.Constants;
using Products.Tests.Fixtures;

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

    [Fact]
    public async Task GetProductsAsync_ReturnsBadRequest_WhenFailure()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(Result.Error(ErrorsNames.ERROR_GET_PRODUCTS));

        // Act
        var result = await _controller.GetProductsAynsc(_mediatorMock.Object, CancellationToken.None);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result.Result);
        Assert.Equal(500, objectResult.StatusCode);
    }

    [Fact]
    public async Task GetProductByIdAsync_ReturnsOk_WhenSuccess()
    {
        // Arrange
        var getProductByIdQuery = new GetProductByIdQuery() { Id = 1 }; 
        var viewModel = ProductsFixtures.GetProductByIdViewModel();

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(Result.Success(viewModel));

        // Act
        var result = await _controller.GetProductByIdAynsc(_mediatorMock.Object, getProductByIdQuery, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsType<GetProductByIdViewModel>(okResult.Value);
    }

    [Fact]
    public async Task GetProductByIdAsync_ReturnsBadRequest_WhenFailure()
    {
        // Arrange
        var getProductByIdQuery = new GetProductByIdQuery() { Id = 1 };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(Result.Error(ErrorsNames.ERROR_GET_PRODUCTS));

        // Act
        var result = await _controller.GetProductByIdAynsc(_mediatorMock.Object, getProductByIdQuery, CancellationToken.None);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result.Result);
        Assert.Equal(500, objectResult.StatusCode);
    }

    [Fact]
    public async Task RemoveProductsAsync_ReturnsOk_WhenSuccess()
    {
        // Arrange
        var command = new RemoveProductsCommand { Id = 1 };
        _mediatorMock.Setup(m => m.Send(It.IsAny<RemoveProductsCommand>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(Result.Success());

        // Act
        var result = await _controller.RemoveProductsAynsc(_mediatorMock.Object, command, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public async Task RemoveProductsAsync_ReturnsBadRequest_WhenFailure()
    {
        // Arrange
        var command = new RemoveProductsCommand { Id = 1 };
        _mediatorMock.Setup(m => m.Send(It.IsAny<RemoveProductsCommand>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(Result.Error(ErrorsNames.ERROR_REMOVE_PRODUCT));

        // Act
        var result = await _controller.RemoveProductsAynsc(_mediatorMock.Object, command, CancellationToken.None);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, objectResult.StatusCode);
    }

    [Fact]
    public async Task CreateProductsAsync_ReturnsOk_WhenSuccess()
    {
        // Arrange
        var command = new CreateProductsCommand 
        { 
            Name = "New Product", 
            Description = "Description",
            Price = 10.0m,
            Items = new List<CreateProductItensCommand>()
            {
                new CreateProductItensCommand
                {
                    BatchNumber ="12345",
                    Quantity = 2
                },
            },
        };
        _mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductsCommand>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(Result.Success());

        // Act
        var result = await _controller.CreateProductsAynsc(_mediatorMock.Object, command, CancellationToken.None);

        // Assert
        var okResult = Assert.IsType<OkResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

}
