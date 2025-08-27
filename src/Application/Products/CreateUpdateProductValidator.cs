using FluentValidation;

namespace Washyn.Kfc.Products;

public class CreateUpdateProductValidator : AbstractValidator<CreateUpdateProduct>
{
    public CreateUpdateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2,10);
        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("Sku must be code(custom message from fluent validation).");
    }
}