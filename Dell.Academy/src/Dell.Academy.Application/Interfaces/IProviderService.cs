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

        Task<OperationResult> UpdateProviderAsync(ProviderViewModel viewModel);

        Task<OperationResult> UpdateAddressAsync(AddressViewModel viewModel);

        Task<OperationResult> DeleteProviderAsync(long id);
    }
}