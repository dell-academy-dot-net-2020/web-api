using Bogus;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Validations;
using System.Linq;
using Xunit;

namespace Dell.Academy.Domain.Tests
{
    public class CategoryValidatorTests
    {
        private readonly Faker _faker;
        private readonly CategoryValidator _validator;

        public CategoryValidatorTests()
        {
            _faker = new Faker("pt_BR");
            _validator = new CategoryValidator();
        }

        [Fact]
        public void ReceiveAValidCategoryName_ShouldValidateCategory()
        {
            // Arrange
            var category = new Category(_faker.Commerce.Categories(1).FirstOrDefault());

            // Act
            var result = _validator.Validate(category);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void ReceiveAnEmptyCategoryName_ShouldValidateCategory()
        {
            // Arrange
            var category = new Category(string.Empty);

            // Act
            var result = _validator.Validate(category);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Nome", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveASmallerSizeCategoryName_ShouldValidateCategory()
        {
            // Arrange
            var category = new Category("C1");

            // Act
            var result = _validator.Validate(category);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Nome", result.Errors.FirstOrDefault().PropertyName);
        }

        [Fact]
        public void ReceiveABiggerSizeCategoryName_ShouldValidateCategory()
        {
            // Arrange
            var category = new Category(_faker.Random.AlphaNumeric(31));

            // Act
            var result = _validator.Validate(category);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal("Nome", result.Errors.FirstOrDefault().PropertyName);
        }
    }
}