using Ardalis.Result;
using FluentValidation;
using MediatR;
using Products.Application.Extensions;
using Products.Domain.Interfaces.Repositories;
using Products.Domain.Interfaces.Services;

namespace Products.Application.Products.Commands.CreateProducts;

public class CreateProductsHandler(IValidator<CreateProductsCommand> validator, IProductsService productsService) : IRequestHandler<CreateProductsCommand, Result>
{
    public async Task<Result> Handle(CreateProductsCommand command, CancellationToken cancellationToken)
    {
        var validatorCommand =  validator.Validate(command);
        
        var result = ValidationResultExtensions.ToResult(validatorCommand);
        if (!result.IsSuccess)
           return Result.Invalid(result.ValidationErrors);

        var createProductDto = ProductsExtensions.ToCreateProductsDto(command);
        
        var createProduct = await productsService.CreateProductsAsync(createProductDto, cancellationToken);
        if(!createProduct.IsSuccess)
            return Result.Error();

        return Result.Success();
    }
}
