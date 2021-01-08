using Bogus;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Validations;
using System.Linq;
using Xunit;

namespace Dell.Academy.Domain.Tests
{
    public class AddressValidatorTests
    {
        private readonly Faker _faker;
        private readonly AddressValidator _validator;

        public AddressValidatorTests()
        {
            _faker = new Faker("pt_BR");
            _validator = new AddressValidator();
        }
        ///
        /////////////////////////////////////STREET//////////////////////////////////////////////////////////////////
        ///
        [Fact]
        public void ReceiveAValidAddressStreet_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyAddressStreet_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(string.Empty);

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
            var address = new Address("C1");

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
            var address = new Address(_faker.Random.AlphaNumeric(31));

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Rua", result.Errors.FirstOrDefault().PropertyName);
        }
        ///
        /////////////////////////////////////NUMBER//////////////////////////////////////////////////////////////////
        ///
        [Fact]
        public void ReceiveAValidAddressNumber_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.True(result.IsValid);
        }

       
        [Fact]
        public void ReceiveABiggerSizeAddressNumber_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(_faker.Random.AlphaNumeric(31));

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Número", result.Errors.FirstOrDefault().PropertyName);
        }
        ///
        /////////////////////////////////////COMPLEMET//////////////////////////////////////////////////////////////////
        ///

        [Fact]
        public void ReceiveAValidAddressComplement_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyAddressComplement_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(string.Empty);

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
            var address = new Address("C1");

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
            var address = new Address(_faker.Random.AlphaNumeric(16));

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Rua", result.Errors.FirstOrDefault().PropertyName);
        }
        ///
        /////////////////////////////////////CEP//////////////////////////////////////////////////////////////////
        ///

        [Fact]
        public void ReceiveAValidAddressCep_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyAddressCep_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(string.Empty);

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("cep", result.Errors.FirstOrDefault().PropertyName);
        }

      

        [Fact]
        public void ReceiveABiggerSizeAddressCep_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(_faker.Random.AlphaNumeric(9));

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cep", result.Errors.FirstOrDefault().PropertyName);
        }
        ///
        /////////////////////////////////////DISTRICT//////////////////////////////////////////////////////////////////
        ///
        [Fact]
        public void ReceiveAValidAddressDistrict_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyAddressDistrict_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(string.Empty);

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
            var address = new Address("C1");

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
            var address = new Address(_faker.Random.AlphaNumeric(31));

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Bairro", result.Errors.FirstOrDefault().PropertyName);
        }

        ///
        /////////////////////////////////////CITY//////////////////////////////////////////////////////////////////
        ///
        [Fact]
        public void ReceiveAValidAddressCity_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyAddressCity_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(string.Empty);

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
            var address = new Address("C1");

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
            var address = new Address(_faker.Random.AlphaNumeric(31));

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Cidade", result.Errors.FirstOrDefault().PropertyName);
        }
        ///
        /////////////////////////////////////STATE//////////////////////////////////////////////////////////////////
        ///
        [Fact]
        public void ReceiveAValidAddressState_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyAddressState_ShouldValidateAddress()
        {
            // Arrange
            var address = new Address(string.Empty);

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
            var address = new Address("C1");

            // Act
            var result = _validator.Validate(address);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Estado", result.Errors.FirstOrDefault().PropertyName);
        }

        
    }
}