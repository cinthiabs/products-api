using Ardalis.Result;
using FluentValidation;
using MediatR;
using Products.Application.Extensions;
using Products.Domain.Interfaces.Repositories;

namespace Products.Application.Products.Commands.CreateProducts;

public class CreateProductsHandler(IValidator<CreateProductsCommand> validator, IProductsRepository productsRepository) : IRequestHandler<CreateProductsCommand, Result>
{
    public async Task<Result> Handle(CreateProductsCommand command, CancellationToken cancellationToken)
    {
        var validatorCommand =  validator.Validate(command);
        
        var result = ValidationResultExtensions.ToResult(validatorCommand);
        if (!result.IsSuccess)
           return Result.Invalid(result.ValidationErrors);

        var createProductDto = ProductsExtensions.ToCreateProductsDto(command);
        
        var createProduct = await productsRepository.CreateProductsAsync(createProductDto, cancellationToken);
        if(createProduct is null)
        {
            return Result.Error();
        }

        return Result.Success();
    }
}
