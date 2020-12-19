using System.Collections.Generic;

namespace Dell.Academy.Application.ViewModels
{
    public class ProviderViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public short ProviderType { get; set; }
        public bool Active { get; set; }
        public AddressViewModel Address { get; set; }
        public List<ProductViewModel> Products { get; private set; }
    }
}