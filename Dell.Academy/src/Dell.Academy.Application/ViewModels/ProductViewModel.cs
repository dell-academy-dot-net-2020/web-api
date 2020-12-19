namespace Dell.Academy.Application.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool Active { get; set; }
        public string Sku { get; set; }
        public string ProviderName { get; set; }
        public long ProviderId { get; set; }
        public string CategoryName { get; set; }
        public long CategoryId { get; set; }
    }
}