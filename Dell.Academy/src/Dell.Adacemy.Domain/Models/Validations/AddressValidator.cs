using FluentValidation;

namespace Dell.Academy.Domain.Models.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Street).NotEmpty().Length(3, 15);

            RuleFor(a => a.Number).NotEmpty();

            RuleFor(a => a.Complement).NotEmpty();

            RuleFor(a => a.Cep).NotEmpty();

            RuleFor(a => a.District).NotEmpty();

            RuleFor(a => a.City).NotEmpty();

            RuleFor(a => a.State).NotEmpty();
        }
    }
}