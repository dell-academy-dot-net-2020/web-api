using Bogus;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Validations;
using System.Linq;
using Xunit;

namespace Dell.Academy.Domain.Tests
{
    public class ProductValidatorTests
    {
        private readonly Faker _faker;
        private readonly ProductValidator _validator;

        public ProductValidatorTests()
        {
            _faker = new Faker("pt_BR");
            _validator = new ProductValidator();
        }
        /// <summary>
        /// //////////////////////////////////////////NAME////////////////////////////////////////////////////
        /// </summary>
        [Fact]
        public void ReceiveAValidProductName_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyProductName_ShouldValidateProduct()
        {
            // Arrange
            var Product = new Product(string.Empty);

            // Act
            var result = _validator.Validate(Product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Nome", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeProductName_ShouldValidateProduct()
        {
            // Arrange
            var Product = new Product("C1");

            // Act
            var result = _validator.Validate(Product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Nome", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeProductName_ShouldValidateProduct()
        {
            // Arrange
            var Product = new Product(_faker.Random.AlphaNumeric(31));

            // Act
            var result = _validator.Validate(Product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Nome", result.Errors.FirstOrDefault().PropertyName);
        }

        /// <summary>
        /// //////////////////////////////////////////DESCRIPITION////////////////////////////////////////////////////
        /// </summary>
        [Fact]
        public void ReceiveAValidProductDescription_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyProductDescription_ShouldValidateProduct()
        {
            // Arrange
            var Product = new Product(string.Empty);

            // Act
            var result = _validator.Validate(Product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Descrição", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeProductDescription_ShouldValidateProduct()
        {
            // Arrange
            var Product = new Product("C1");

            // Act
            var result = _validator.Validate(Product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Descrição", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeProductDescription_ShouldValidateProduct()
        {
            // Arrange
            var Product = new Product(_faker.Random.AlphaNumeric(51));

            // Act
            var result = _validator.Validate(Product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Descrição", result.Errors.FirstOrDefault().PropertyName);
        }

        /// <summary>
        /// //////////////////////////////////////////SKU////////////////////////////////////////////////////
        /// </summary>
        [Fact]
        public void ReceiveAValidProductSku_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyProductSku_ShouldValidateProduct()
        {
            // Arrange
            var Product = new Product(string.Empty);

            // Act
            var result = _validator.Validate(Product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("",result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeProductSku_ShouldValidateProduct()
        {
            // Arrange
            var Product = new Product("C1");

            // Act
            var result = _validator.Validate(Product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Descrição", result.Errors.FirstOrDefault().PropertyName);
        }

        /// <summary>
        /// //////////////////////////////////////////VALUE////////////////////////////////////////////////////
        /// </summary>

        [Fact]
        public void ReceiveAValidProductValue_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyProductValue_ShouldValidateProduct()
        {
            // Arrange
            var Product = new Product(string.Empty);

            // Act
            var result = _validator.Validate(Product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Valor", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeProductValue_ShouldValidateProduct()
        {
            // Arrange
            var Product = new Product("C1");

            // Act
            var result = _validator.Validate(Product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Valor", result.Errors.FirstOrDefault().PropertyName);
        }

        /// <summary>
        /// //////////////////////////////////////////REGISTER////////////////////////////////////////////////////
        /// </summary>
        /// 

        [Fact]
        public void ReceiveAValidProductRegister_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.True(result.IsValid);
        }

        

        [Fact]
        public void ReceiveABiggerSizeProductRegister_ShouldValidateProduct()
        {
            // Arrange
            var Product = new Product(_faker.Random.AlphaNumeric(31));

            // Act
            var result = _validator.Validate(Product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Registro", result.Errors.FirstOrDefault().PropertyName);
        }

    }
}