using Dell.Academy.Domain.Models.Validations.Utils;

namespace Dell.Academy.Domain.Models
{
    public class Address : BaseEntity
    {
        public string Street { get; private set; }
        public int Number { get; private set; }
        public string Complement { get; private set; }
        public string Cep { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }

        public long ProviderId { get; private set; }
        public Provider Provider { get; private set; }

        public Address()
        {
        }

        public Address(string street, int number, string complement, string cep, string district, string city, string state)
        {
            Street = street;
            Number = number;
            Complement = complement;
            Cep = Utils.OnlyNumbers(cep);
            District = district;
            City = city;
            State = state;
        }
    }
}