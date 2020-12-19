using AutoMapper;
using Dell.Academy.Application.Extensions;
using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Extensions;
using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Validations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Dell.Academy.Application.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult> GetCategoryByIdAsync(long id)
        {
            var category = await _repository.GetCategoryWithAllProductsByIdAsync(id);
            if (category is null)
                return Error(ErrorMessages.NotFoundError("Categoria", id), HttpStatusCode.NotFound);

            return Success(_mapper.Map<CategoryViewModel>(category));
        }

        public async Task<OperationResult> GetCategoriesAsync()
        {
            var categories = await _repository.GetAllAsync();
            return Success(_mapper.Map<List<CategoryViewModel>>(categories));
        }

        public async Task<OperationResult> InsertCategoryAsync(CategoryViewModel viewModel)
        {
            var category = _mapper.Map<Category>(viewModel);
            if (!EntityIsValid(new CategoryValidator(), category))
                return ValidationErrors();

            var categoryExists = await _repository.CategoryWithNameExistsAsync(viewModel.Name);
            if (categoryExists)
                return Error(ErrorMessages.CategoryNameExistsError);

            return Commit(await _repository.InsertAsync(category));
        }

        public async Task<OperationResult> UpdateCategoryAsync(CategoryViewModel viewModel)
        {
            var category = _mapper.Map<Category>(viewModel);
            if (!EntityIsValid(new CategoryValidator(), category))
                return ValidationErrors();

            var categoryFomDb = await _repository.GetByIdAsync(category.Id);
            if (categoryFomDb is null)
                return Error(ErrorMessages.NotFoundError("Categoria", category.Id), HttpStatusCode.NotFound);

            return Commit(await _repository.UpdateAsync(category));
        }

        public async Task<OperationResult> DeleteCategoryAsync(long id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
                return Error(ErrorMessages.NotFoundError("Categoria", id), HttpStatusCode.NotFound);

            return Commit(await _repository.DeleteAsync(id));
        }
    }
}