using FluentValidation;

namespace Washyn.Kfc;

public class CreateUpdateProductValidator : AbstractValidator<CreateUpdateProduct>
{
    public CreateUpdateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2,10);
        RuleFor(x => x.Price)
            .NotEmpty()
            .Must(Positive)
            .WithMessage("Price must be positive(custom message from fluent validation).");
    }

    private bool Positive(decimal arg)
    {
        return arg > 0;   
    }
}