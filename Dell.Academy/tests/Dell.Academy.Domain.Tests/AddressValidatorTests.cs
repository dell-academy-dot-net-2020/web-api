using Bogus;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Validations;
using System.Linq;
using Xunit;

namespace Dell.Academy.Domain.Tests
{
    [Collection(nameof(DomainTestsCollection))]
    public class AddressValidatorTests
    {
        private readonly Faker _faker;
        private readonly AddressValidator _validator;

        public AddressValidatorTests(DomainFixture fixture)
        {
            _faker = fixture.Faker;
            _validator = new AddressValidator();
        }

        ///
        /////////////////////////////////////STREET//////////////////////////////////////////////////////////////////
        ///
        [Fact]
        public void ReceiveAValidAddress_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, "Test Complement", "60.000-000", "Test District", "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyAddressStreet_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(string.Empty, 1, "Test Complement", "60.000-000", "Test District", "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Rua", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeAddressStreet_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("S1", 1, "Test Complement", "60.000-000", "Test District", "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Rua", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeAddressStreet_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(_faker.Random.AlphaNumeric(31), 1, "Test Complement", "60.000-000", "Test District", "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Rua", result.Errors.FirstOrDefault().PropertyName);
        }

        /////
        ///////////////////////////////////////NUMBER//////////////////////////////////////////////////////////////////
        /////

        [Fact]
        public void ReceiveASmallerAddressNumber_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", _faker.Random.Number(-10, 0), "Test Complement", "60.000-000", "Test District", "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Número", result.Errors.FirstOrDefault().PropertyName);
        }

        ///
        ///////////////////////////////////////COMPLEMET//////////////////////////////////////////////////////////////////
        /////

        [Fact]
        public void ReceiveAnEmptyAddressComplement_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, string.Empty, "60.000-000", "Test District", "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Complemento", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeAddressComplement_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, "C1", "60.000-000", "Test District", "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Complemento", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeAddressComplement_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, _faker.Random.AlphaNumeric(16), "60.000-000", "Test District", "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Complemento", result.Errors.FirstOrDefault().PropertyName);
        }

        /////
        ///////////////////////////////////////CEP//////////////////////////////////////////////////////////////////
        /////

        [Fact]
        public void ReceiveAnEmptyAddressCep_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, "Test Complement", string.Empty, "Test District", "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cep", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeAddressCep_ShouldValidateAddress()
        {
            // Arrange;
            var address = new Address("Test Street", 1, "Test Complement", _faker.Random.AlphaNumeric(9), "Test District", "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cep", result.Errors.FirstOrDefault().PropertyName);
        }

        /////
        ///////////////////////////////////////DISTRICT//////////////////////////////////////////////////////////////////
        /////

        [Fact]
        public void ReceiveAnEmptyAddressDistrict_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, "Test Complement", "60.000-000", string.Empty, "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Bairro", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeAddressDistrict_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, "Test Complement", "60.000-000", "D1", "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Bairro", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeAddressDistrict_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, "Test Complement", "60.000-000", _faker.Random.AlphaNumeric(31), "Test City", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Bairro", result.Errors.FirstOrDefault().PropertyName);
        }

        /////
        ///////////////////////////////////////CITY//////////////////////////////////////////////////////////////////
        /////

        [Fact]
        public void ReceiveAnEmptyAddressCity_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, "Test Complement", "60.000-000", "Test District", string.Empty, "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cidade", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeAddressCity_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, "Test Complement", "60.000-000", "Test District", "C1", "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cidade", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeAddressCity_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, "Test Complement", "60.000-000", "Test District", _faker.Random.AlphaNumeric(31), "TE");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cidade", result.Errors.FirstOrDefault().PropertyName);
        }

        /////
        ///////////////////////////////////////STATE//////////////////////////////////////////////////////////////////
        /////

        [Fact]
        public void ReceiveAnEmptyAddressState_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, "Test Complement", "60.000-000", "Test District", "Test City", string.Empty);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Estado", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeAddressState_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address("Test Street", 1, "Test Complement", "60.000-000", "Test District", "Test City", "Test");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Estado", result.Errors.FirstOrDefault().PropertyName);
        }
    }
}