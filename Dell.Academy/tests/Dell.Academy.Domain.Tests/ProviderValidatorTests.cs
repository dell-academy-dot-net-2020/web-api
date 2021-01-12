using Bogus;
using Bogus.Extensions.Brazil;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Enums;
using Dell.Academy.Domain.Models.Validations;
using Xunit;

namespace Dell.Academy.Domain.Tests
{
    [Collection(nameof(DomainTestsCollection))]
    public class ProviderValidatorTests
    {
        private readonly Faker _faker;
        private readonly ProviderValidator _validator;

        public ProviderValidatorTests(DomainFixture fixture)
        {
            _faker = fixture.Faker;
            _validator = new ProviderValidator();
        }

        [Fact]
        public void ReceiveAValidCompanyProvider_ShouldValidateProvider()
        {
            // Arrange
            var provider = new Provider("Test Name", _faker.Company.Cnpj(), ProviderType.Company, true, null, null);

            // Act
            var result = _validator.Validate(provider);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAValidPersonProvider_ShouldValidateProvider()
        {
            // Arrange
            var provider = new Provider("Test Name", _faker.Person.Cpf(), ProviderType.Person, true, null, null);

            // Act
            var result = _validator.Validate(provider);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}