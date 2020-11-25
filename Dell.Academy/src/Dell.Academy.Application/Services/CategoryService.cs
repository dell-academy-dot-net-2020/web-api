using AutoMapper;
using Dell.Academy.Application.Interfaces;
using Dell.Academy.Application.ViewModels;
using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Dell.Academy.Domain.Models.Validations;
using System;
using System.Linq;
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

        public async Task InsertCategoryAsync(CategoryViewModel viewModel)
        {
            var category = _mapper.Map<Category>(viewModel);
            var validator = new CategoryValidator();
            if (!validator.Validate(category).IsValid)
                throw new ApplicationException(validator.Validate(category).Errors.FirstOrDefault().ErrorMessage);

            var categoryExists = await _repository.CategoryWithNameExistsAsync(viewModel.Name);
            if (categoryExists)
                throw new ApplicationException("Categoria já cadastrada!");

            var commitResult = await _repository.InsertAsync(category);
            if (!commitResult)
                throw new ApplicationException("Não foi possível salvar o registro no banco de dados.");
        }
    }
}