using AutoMapper;
using Dell.Academy.Application.Extensions;
using Dell.Academy.Application.Extensions.Exceptions;
using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryViewModel> GetCategoryByIdAsync(long id)
        {
            var category = await _repository.GetCategoryWithAllProductsByIdAsync(id);
            if (category is null)
                throw new NotFoundException(ErrorMessages.NotFoundError("Categoria", id));

            return _mapper.Map<CategoryViewModel>(category);
        }

        public async Task<List<CategoryViewModel>> GetCategoriesAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryViewModel>>(categories);
        }

        public async Task InsertCategoryAsync(CategoryViewModel viewModel)
        {
            var category = _mapper.Map<Category>(viewModel);
            var validator = new CategoryValidator();
            var validationResult = validator.Validate(category);
            if (!validationResult.IsValid)
                throw new ValidationException(ErrorMessages.ValidationErrors(validationResult));

            var categoryExists = await _repository.CategoryWithNameExistsAsync(viewModel.Name);
            if (categoryExists)
                throw new CategoryException(ErrorMessages.CategoryNameExistsError);

            var commitResult = await _repository.InsertAsync(category);
            if (!commitResult)
                throw new DatabaseCommitException(ErrorMessages.DatabaseCommitError);
        }

        public async Task UpdateCategoryAsync(CategoryViewModel viewModel, long id)
        {
            if (id != viewModel.Id)
                throw new Exception("Os Id's não correspondem");

            var category = _mapper.Map<Category>(viewModel);
            var validator = new CategoryValidator();
            var validationResult = validator.Validate(category);
            if (!validationResult.IsValid)
                throw new ValidationException(ErrorMessages.ValidationErrors(validationResult));

            var categoryFomDb = await _repository.GetByIdAsync(category.Id);
            if (categoryFomDb is null)
                throw new NotFoundException(ErrorMessages.NotFoundError("Categoria", category.Id));

            var commitResult = await _repository.UpdateAsync(category);
            if (!commitResult)
                throw new DatabaseCommitException(ErrorMessages.DatabaseCommitError);
        }

        public async Task DeleteCategoryAsync(long id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
                throw new NotFoundException(ErrorMessages.NotFoundError("Categoria", id));

            await _repository.DeleteAsync(id);
        }
    }
}