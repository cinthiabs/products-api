using Ardalis.Result;
using FluentValidation;
using MediatR;
using Products.Application.Extensions;

namespace Products.Application.Products.Commands.CreateProducts;

public class CreateProductsHandler(IValidator<CreateProductsCommand> validator) : IRequestHandler<CreateProductsCommand, Result>
{
    public async Task<Result> Handle(CreateProductsCommand command, CancellationToken cancellationToken)
    {
        var validatorCommand =  validator.Validate(command);
        var result = ValidationResultExtensions.ToResult(validatorCommand);
        if (!result.IsSuccess)
           return Result.Invalid(result.ValidationErrors);


        throw new NotImplementedException();
    }
}
