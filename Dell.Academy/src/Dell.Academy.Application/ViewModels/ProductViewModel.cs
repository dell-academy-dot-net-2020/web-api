using System;

namespace Dell.Academy.Application.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Register { get; set; }
        public bool Active { get; set; }
        public string ProviderName { get; set; }
        public string CategoryName { get; set; }
    }
}