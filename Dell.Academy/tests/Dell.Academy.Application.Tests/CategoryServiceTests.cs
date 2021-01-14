using AutoMapper;
using Dell.Academy.Application.Services;
using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Extensions;
using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Moq;
using Moq.AutoMock;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Dell.Academy.Application.Tests
{
    public class CategoryServiceTests
    {
        private readonly AutoMocker _autoMocker;
        private readonly CategoryService _service;

        public CategoryServiceTests()
        {
            _autoMocker = new AutoMocker();
            _service = _autoMocker.CreateInstance<CategoryService>();
        }

        [Fact]
        public async void GetCategoryByIdAsync_AValidId_ShouldReturnSuccessWithACategoryViewModel()
        {
            // Arrange
            var category = new Category("Test Name");
            var mockedRepository = _autoMocker.GetMock<ICategoryRepository>();
            mockedRepository.Setup(r => r.GetCategoryWithAllProductsByIdAsync(1)).ReturnsAsync(category);
            var mockedMapper = _autoMocker.GetMock<IMapper>();
            mockedMapper.Setup(m => m.Map<CategoryViewModel>(category)).Returns(new CategoryViewModel { Name = category.Name });

            // Act
            var result = await _service.GetCategoryByIdAsync(1);

            // Assert
            Assert.True(result.IsValid);
            Assert.NotNull(result.Content);
            Assert.Equal(category.Name, ((CategoryViewModel)result.Content).Name);
        }

        [Fact]
        public async void GetCategoryByIdAsync_AnInValidId_ShouldReturnOperationResultWithNotFoundError()
        {
            // Arrange, Act
            var result = await _service.GetCategoryByIdAsync(1);

            // Assert
            Assert.False(result.IsValid);
            Assert.Null(result.Content);
            Assert.Equal(ErrorMessages.NotFoundError("Categoria", 1), result.Result.Errors.FirstOrDefault().ErrorMessage);
        }

        [Fact]
        public async void GetCategoriesAsync_ShouldReturnSuccessWithAListOfCategoryViewModel()
        {
            // Arrange
            var categories = _autoMocker.GetMock<List<Category>>().Object;
            var mockedRepository = _autoMocker.GetMock<ICategoryRepository>();
            mockedRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);
            var mockedMapper = _autoMocker.GetMock<IMapper>();
            mockedMapper.Setup(m => m.Map<List<CategoryViewModel>>(categories))
                .Returns(new List<CategoryViewModel>());

            // Act
            var result = await _service.GetCategoriesAsync();

            // Assert
            Assert.True(result.IsValid);
            Assert.NotNull(result.Content);
            Assert.IsType<List<CategoryViewModel>>(result.Content);
        }

        [Fact]
        public async void InsertCategoryAsync_AValidCategoryViewModel_ShouldReturnCommitWithSuccess()
        {
            // Arrange
            var categoryViewModel = new CategoryViewModel { Name = "Test Name" };
            var category = new Category(categoryViewModel.Name);

            var mockedMapper = _autoMocker.GetMock<IMapper>();
            mockedMapper.Setup(m => m.Map<Category>(categoryViewModel)).Returns(category);

            var mockedRepository = _autoMocker.GetMock<ICategoryRepository>();
            mockedRepository.Setup(r => r.CategoryWithNameExistsAsync(categoryViewModel.Name)).ReturnsAsync(false);
            mockedRepository.Setup(r => r.InsertAsync(category)).ReturnsAsync(true);

            // Act
            var result = await _service.InsertCategoryAsync(categoryViewModel);

            // Assert
            Assert.True(result.IsValid);
            mockedRepository.Verify(r => r.InsertAsync(category), Times.Once);
        }

        [Fact]
        public async void InsertCategoryAsync_AInValidCategoryViewModel_ShouldReturnOperationResultWithValidationErrors()
        {
            // Arrange
            var categoryViewModel = new CategoryViewModel { Name = string.Empty };
            var category = new Category(categoryViewModel.Name);

            var mockedMapper = _autoMocker.GetMock<IMapper>();
            mockedMapper.Setup(m => m.Map<Category>(categoryViewModel)).Returns(category);

            var mockedRepository = _autoMocker.GetMock<ICategoryRepository>();

            // Act
            var result = await _service.InsertCategoryAsync(categoryViewModel);

            // Assert
            Assert.False(result.IsValid);
            mockedRepository.Verify(r => r.InsertAsync(category), Times.Never);
        }

        [Fact]
        public async void InsertCategoryAsync_AnExistsCategoryViewModel_ShouldReturnOperationResultWithCategoryNameExistsError()
        {
            // Arrange
            var categoryViewModel = new CategoryViewModel { Name = "Test Name" };
            var category = new Category(categoryViewModel.Name);

            var mockedMapper = _autoMocker.GetMock<IMapper>();
            mockedMapper.Setup(m => m.Map<Category>(categoryViewModel)).Returns(category);

            var mockedRepository = _autoMocker.GetMock<ICategoryRepository>();
            mockedRepository.Setup(r => r.CategoryWithNameExistsAsync(category.Name)).ReturnsAsync(true);

            // Act
            var result = await _service.InsertCategoryAsync(categoryViewModel);

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(ErrorMessages.CategoryNameExistsError, result.Result.Errors.FirstOrDefault().ErrorMessage);
            mockedRepository.Verify(r => r.InsertAsync(category), Times.Never);
        }
    }
}