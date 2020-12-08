using Dell.Academy.Domain.Models.Enums;
using Dell.Academy.Domain.Models.Validations;
using Dell.Academy.Domain.Models.Validations.Utils;
using System.Collections.Generic;

namespace Dell.Academy.Domain.Models
{
    public class Provider : BaseEntity
    {
        public string Name { get; private set; }
        public string DocumentNumber { get; private set; }
        public ProviderType ProviderType { get; private set; }
        public bool Active { get; private set; }
        public Address Address { get; private set; }
        public List<Product> Products { get; private set; }

        // EF Relational
        public Provider()
        {
        }

        public Provider(string name, string documentNumber, ProviderType providerType, bool active, Address address, List<Product> products)
        {
            Name = name;
            DocumentNumber = Utils.OnlyNumbers(documentNumber);
            ProviderType = providerType;
            Active = active;
            Address = new AddressValidator().Validate(address).IsValid ? address : null;
            Products = products;
        }
    }
}