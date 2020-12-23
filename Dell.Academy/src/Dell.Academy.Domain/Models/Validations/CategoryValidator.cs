using FluentValidation;

namespace Dell.Academy.Domain.Models.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.Name).NotEmpty().Length(3, 30).OverridePropertyName("Nome");
        }
    }
}