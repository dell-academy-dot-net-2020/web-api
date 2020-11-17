using System;

namespace Dell.Academy.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public DateTime Register { get; private set; }
        public bool Active { get; private set; }

        public long ProviderId { get; private set; }
        public Provider Provider { get; private set; }

        public long CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Product(string name, string description, decimal value, DateTime register, bool active, long providerId, long categoryId)
        {
            Name = name;
            Description = description;
            Value = value;
            Register = register;
            Active = active;
            ProviderId = providerId;
            CategoryId = categoryId;
        }
    }
}