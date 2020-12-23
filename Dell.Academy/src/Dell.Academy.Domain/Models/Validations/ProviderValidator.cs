using Dell.Academy.Domain.Extensions;
using Dell.Academy.Domain.Models.Enums;
using Dell.Academy.Domain.Models.Validations.Utils;
using FluentValidation;

namespace Dell.Academy.Domain.Models.Validations
{
    public class ProviderValidator : AbstractValidator<Provider>
    {
        public ProviderValidator()
        {
            RuleFor(p => p.Name).NotEmpty().Length(3, 30).OverridePropertyName("Nome");

            When(p => p.ProviderType == ProviderType.Person, () =>
            {
                RuleFor(p => p.DocumentNumber.Length == CpfValidation.CpfSize).Equal(true).WithMessage(ErrorMessages.CpfSizeError);
                RuleFor(p => CpfValidation.Validate(p.DocumentNumber)).Equal(true).WithMessage(ErrorMessages.CpfInvalidError);
            });

            When(p => p.ProviderType == ProviderType.Company, () =>
            {
                RuleFor(p => p.DocumentNumber.Length == CnpjValidation.CnpjSize).Equal(true).WithMessage(ErrorMessages.CnpjSizeError);
                RuleFor(p => CnpjValidation.Validate(p.DocumentNumber)).Equal(true).WithMessage(ErrorMessages.CnpjInvalidError);
            });
        }
    }
}