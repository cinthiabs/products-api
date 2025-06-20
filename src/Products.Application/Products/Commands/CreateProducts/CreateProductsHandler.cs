using Ardalis.Result;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Products.Application.Extensions;
using Products.Domain.Constants;
using Products.Domain.Interfaces.Services;

namespace Products.Application.Products.Commands.CreateProducts;

public class CreateProductsHandler(ILogger<CreateProductsHandler> logger, IValidator<CreateProductsCommand> validator, IProductsService productsService) : IRequestHandler<CreateProductsCommand, Result>
{
    public async Task<Result> Handle(CreateProductsCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var validatorCommand = validator.Validate(command);

            var result = ValidationResultExtensions.ToResult(validatorCommand);
            if (!result.IsSuccess)
                return Result.Invalid(result.ValidationErrors);

            var createProductDto = ProductsExtensions.ToCreateProductsDto(command);

            var createProduct = await productsService.CreateProductsAsync(createProductDto, cancellationToken);
            if (!createProduct.IsSuccess)
                return Result.Error(ErrorsNames.ERROR_CREATE_PRODUCT);

            return Result.Success();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, Logs.LOG_ERROR, ProcessNames.PROCESS_CREATE_PRODUCT, ErrorsNames.ERROR_CREATE_PRODUCT, ex.Message);
            return Result.CriticalError(ErrorsNames.ERROR_CREATE_PRODUCT);
        }
    }
}
