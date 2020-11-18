using FluentValidation;

namespace Dell.Academy.Domain.Models.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Street).NotEmpty().Length(3, 15);

            RuleFor(a => a.Number).GreaterThan(0);

            RuleFor(a => a.Complement).Length(3, 15);

            RuleFor(a => a.Cep).NotEmpty().Length(8);

            RuleFor(a => a.District).NotEmpty().Length(3, 15);

            RuleFor(a => a.City).NotEmpty().Length(3, 15);

            RuleFor(a => a.State).NotEmpty().Length(2);
        }
    }
}