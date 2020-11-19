using System.Collections.Generic;

namespace Dell.Academy.Domain.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }
        public List<Product> Products { get; set; }

        public Category()
        {
        }

        public Category(string name) => Name = name;
    }
}