using Dell.Academy.Application.Extensions;
using Dell.Academy.Application.ViewModels;
using System.Threading.Tasks;

namespace Dell.Academy.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<OperationResult> GetCategoryByIdAsync(long id);

        Task<OperationResult> GetCategoriesAsync();

        Task<OperationResult> InsertCategoryAsync(CategoryViewModel viewModel);

        Task<OperationResult> UpdateCategoryAsync(CategoryViewModel viewModel);

        Task<OperationResult> DeleteCategoryAsync(long id);
    }
}