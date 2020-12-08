using Dell.Academy.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Domain.Interfaces
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<Provider> GetProviderWithAddressAndProductsByIdAsync(long id);

        Task<List<Provider>> GetProvidersWithAddressAsync();

        Task<bool> ProviderWithDocumentNumberExistsAsync(string documentNumber);
    }
}