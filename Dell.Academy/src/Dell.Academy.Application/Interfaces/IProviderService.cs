using Dell.Academy.Application.Extensions;
using Dell.Academy.Application.ViewModels;
using System.Threading.Tasks;

namespace Dell.Academy.Application.Interfaces
{
    public interface IProviderService
    {
        Task<OperationResult> GetProvidersAsync();

        Task<OperationResult> GetProviderByIdAsync(long id);

        Task<OperationResult> InsertProviderAsync(ProviderViewModel viewModel);
    }
}