using FluentValidation;

namespace Dell.Academy.Domain.Models.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(pd => pd.Name).NotEmpty().Length(3, 15);

            RuleFor(pd => pd.Description).NotEmpty().Length(3, 15);

            RuleFor(pd => pd.Value).NotEmpty();

            RuleFor(pd => pd.Register).NotEmpty();

            RuleFor(pd => pd.Active).NotEmpty(); 

            RuleFor(pd => pd.Provider).NotEmpty();

            RuleFor(pd => pd.Category).NotEmpty();
        }
    }
}
