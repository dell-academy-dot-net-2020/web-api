using Dell.Academy.Application.Extensions;
using Dell.Academy.Application.ViewModels;
using System.Threading.Tasks;

namespace Dell.Academy.Application.Interfaces
{
    public interface IProductService
    {
        Task<OperationResult> GetProductsAsync();

        Task<OperationResult> GetProductByIdAsync(long id);

        Task<OperationResult> InsertProductAsync(ProductViewModel viewModel);

        Task<OperationResult> UpdateProductAsync(ProductViewModel viewModel);

        Task<OperationResult> DeleteProductAsync(long id);
    }
}