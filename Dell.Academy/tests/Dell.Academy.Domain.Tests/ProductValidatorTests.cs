using Bogus;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Validations;
using System;
using System.Linq;
using Xunit;

namespace Dell.Academy.Domain.Tests
{
    [Collection(nameof(DomainTestsCollection))]
    public class ProductValidatorTests
    {
        private readonly Faker _faker;
        private readonly ProductValidator _validator;

        public ProductValidatorTests(DomainFixture fixture)
        {
            _faker = fixture.Faker;
            _validator = new ProductValidator();
        }

        /// <summary>
        /// //////////////////////////////////////////NAME////////////////////////////////////////////////////
        /// </summary>
        [Fact]
        public void ReceiveAValidProduct_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product("Test Name", "Test Description", 100, true, "TestS1", 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyProductName_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product(string.Empty, "Test Description", 100, true, "TestS1", 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Nome", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeProductName_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product("P1", "Test Description", 100, true, "TestS1", 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Nome", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeProductName_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product(_faker.Random.AlphaNumeric(31), "Test Description", 100, true, "TestS1", 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Nome", result.Errors.FirstOrDefault().PropertyName);
        }

        ///// <summary>
        ///// //////////////////////////////////////////DESCRIPITION////////////////////////////////////////////////////
        ///// </summary>

        [Fact]
        public void ReceiveAnEmptyProductDescription_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product("Test Name", string.Empty, 100, true, "TestS1", 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Descrição", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeProductDescription_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product("Test Name", "D1", 100, true, "TestS1", 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Descrição", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeProductDescription_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product("Test Name", _faker.Random.AlphaNumeric(51), 100, true, "TestS1", 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Descrição", result.Errors.FirstOrDefault().PropertyName);
        }

        ///// <summary>
        ///// //////////////////////////////////////////SKU////////////////////////////////////////////////////
        ///// </summary>

        [Fact]
        public void ReceiveAnEmptyProductSku_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product("Test Name", "Test Description", 100, true, string.Empty, 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Sku", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeProductSku_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product("Test Name", "Test Description", 100, true, "P1", 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Sku", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeProductSku_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product("Test Name", "Test Description", 100, true, _faker.Random.AlphaNumeric(7), 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Sku", result.Errors.FirstOrDefault().PropertyName);
        }

        ///// <summary>
        ///// //////////////////////////////////////////VALUE////////////////////////////////////////////////////
        ///// </summary>

        [Fact]
        public void ReceiveAnEmptyProductValue_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product("Test Name", "Test Description", 0, true, "TestS1", 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Valor", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerProductValue_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product("Test Name", "Test Description", -50, true, "TestS1", 1, 1);

            // Act
            var result = _validator.Validate(product);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Valor", result.Errors.FirstOrDefault().PropertyName);
        }

        ///// <summary>
        ///// //////////////////////////////////////////REGISTER////////////////////////////////////////////////////
        ///// </summary>
        /////

        [Fact]
        public void ReceiveAProductWithoutProviderId_ShouldValidateProduct()
        {
            // Arrange
            var product = new Product("Test Name", "Test Description", 100, true, "TestS1", 0, 1);

            // Act
            product.SetProductRegister(DateTime.Now.Date);

            // Assert
            Assert.Equal(DateTime.Now.Date, product.Register);
        }
    }
}