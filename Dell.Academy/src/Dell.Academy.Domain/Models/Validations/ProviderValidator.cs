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
            RuleFor(p => p.Name);
        }
    }
}