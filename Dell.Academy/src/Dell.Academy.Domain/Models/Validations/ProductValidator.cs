using FluentValidation;
using System;

namespace Dell.Academy.Domain.Models.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(pd => pd.Name).NotEmpty().Length(3, 30).OverridePropertyName("Nome");

            RuleFor(pd => pd.Description).NotEmpty().Length(3, 50).OverridePropertyName("Descrição");

            RuleFor(pd => pd.Sku).NotEmpty().Length(6);

            RuleFor(pd => pd.Value).NotEmpty().GreaterThan(0).OverridePropertyName("Valor");

            RuleFor(pd => pd.Register).LessThanOrEqualTo(DateTime.UtcNow).OverridePropertyName("Resgitros");
        }
    }
}