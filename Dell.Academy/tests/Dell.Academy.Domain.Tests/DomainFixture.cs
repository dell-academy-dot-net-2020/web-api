using Bogus;

namespace Dell.Academy.Domain.Tests
{
    public class DomainFixture
    {
        public Faker Faker => new Faker("pt_BR");
    }
}