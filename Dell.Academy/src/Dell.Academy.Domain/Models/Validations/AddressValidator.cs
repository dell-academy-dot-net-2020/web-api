using FluentValidation;

namespace Dell.Academy.Domain.Models.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Street).NotEmpty().Length(3, 30).OverridePropertyName("Rua");

            RuleFor(a => a.Number).GreaterThan(0).OverridePropertyName("Número");

            RuleFor(a => a.Complement).Length(3, 15).OverridePropertyName("Complemento");

            RuleFor(a => a.Cep).NotEmpty().Length(8);

            RuleFor(a => a.District).NotEmpty().Length(3, 30).OverridePropertyName("Bairro");

            RuleFor(a => a.City).NotEmpty().Length(3, 30).OverridePropertyName("Cidade");

            RuleFor(a => a.State).NotEmpty().Length(2).OverridePropertyName("Estado");
        }
    }
}