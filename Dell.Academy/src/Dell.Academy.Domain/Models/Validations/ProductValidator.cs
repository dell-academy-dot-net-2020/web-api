using FluentValidation;
using Microsoft.VisualBasic;

namespace Dell.Academy.Domain.Models.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(pd => pd.Name).NotEmpty().Length(3, 15).OverridePropertyName("Nome");

            RuleFor(pd => pd.Description).NotEmpty().Length(3, 30).OverridePropertyName("Descrição");

            RuleFor(pd => pd.Value).NotEmpty().GreaterThan(0).OverridePropertyName("Valor");

            RuleFor(pd => pd.Register).Equal(DateAndTime.Now).OverridePropertyName("Resgitros");
        }
    }
}