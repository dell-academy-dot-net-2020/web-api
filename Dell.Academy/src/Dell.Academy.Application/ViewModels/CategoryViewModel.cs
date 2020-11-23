using Dell.Academy.Domain.Models;
using System.Collections.Generic;

namespace Dell.Academy.Application.ViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}