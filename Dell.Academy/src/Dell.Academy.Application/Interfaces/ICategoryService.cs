using Dell.Academy.Application.ViewModels;
using System.Threading.Tasks;

namespace Dell.Academy.Application.Interfaces
{
    public interface ICategoryService
    {
        Task InsertCategoryAsync(CategoryViewModel viewModel);
    }
}