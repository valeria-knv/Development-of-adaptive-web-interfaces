using FluentValidation;

namespace LR2
{
    public class ProductValidator : AbstractValidator<ProductFluentValidation>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Product name cannot be empty");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }
}
