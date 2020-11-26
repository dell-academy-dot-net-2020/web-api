using Dell.Academy.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryViewModel> GetCategoryByIdAsync(long id);

        Task<List<CategoryViewModel>> GetCategoriesAsync();

        Task InsertCategoryAsync(CategoryViewModel viewModel);
    }
}