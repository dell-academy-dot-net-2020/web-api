using System.Collections.Generic;

namespace Dell.Academy.Application.ViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}