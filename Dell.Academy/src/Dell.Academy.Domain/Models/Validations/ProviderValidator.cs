using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dell.Academy.Domain.Models.Validations
{
    public class ProviderValidator : AbstractValidator<Provider>
    {
        public ProviderValidator()
        {
            RuleFor(p => p.Name).NotEmpty().Length(3, 15);

            RuleFor(p => p.DocumentNumber).NotEmpty().Length(3, 15);

            RuleFor(p => p.ProviderType).NotEmpty();

            RuleFor(p => p.Active).NotEmpty();

            RuleFor(p => p.Address).NotEmpty();

            RuleFor(p => p.Products).NotEmpty();
        }
    }
}