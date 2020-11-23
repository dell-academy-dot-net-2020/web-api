namespace Dell.Academy.Application.ViewModels
{
    public class AddressViewModel
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string Cep { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public long ProviderId { get; set; }
    }
}