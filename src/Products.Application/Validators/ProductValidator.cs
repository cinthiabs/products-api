using FluentValidation;
using Products.Application.Products.Commands.CreateProducts;

namespace Products.Application.Validators;

public class ProductValidator : AbstractValidator<CreateProductsCommand>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required");

        RuleFor(x => x.Description)
           .NotEmpty().WithMessage("Description is required");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("The value can't be negative");

        RuleForEach(x => x.Items)
           .ChildRules(items =>
           {
               items.RuleFor(i => i.BatchNumber)
                   .MaximumLength(8).WithMessage("The BatchNumber should have 5 characters.");

               items.RuleFor(i => i.Quantity)
                    .GreaterThanOrEqualTo(0).WithMessage("The value can't be negative");
           });
    }
}
