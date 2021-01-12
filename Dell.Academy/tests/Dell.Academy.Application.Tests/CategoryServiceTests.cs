using AutoMapper;
using Dell.Academy.Application.Services;
using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace Dell.Academy.Application.Tests
{
    public class CategoryServiceTests
    {
        [Fact]
        public async void GetCategoryByIdAsync_AValidId_ShouldReturnSuccessWithACategoryViewModel()
        {
            // Arrange
            var mocker = new AutoMocker();
            var category = new Category("Test Name");
            var mockedRepository = mocker.GetMock<ICategoryRepository>();
            mockedRepository.Setup(r => r.GetCategoryWithAllProductsByIdAsync(1)).ReturnsAsync(category);
            var mockedMapper = mocker.GetMock<IMapper>();
            mockedMapper.Setup(m => m.Map<CategoryViewModel>(category)).Returns(new CategoryViewModel { Name = category.Name });
            var service = mocker.CreateInstance<CategoryService>();

            // Act
            var result = await service.GetCategoryByIdAsync(1);

            // Assert
            Assert.True(result.IsValid);
            Assert.NotNull(result.Content);
            Assert.Equal(category.Name, ((CategoryViewModel)result.Content).Name);
        }
    }
}