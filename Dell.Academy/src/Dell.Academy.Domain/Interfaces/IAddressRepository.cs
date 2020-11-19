using Dell.Academy.Domain.Models;
using System.Threading.Tasks;

namespace Dell.Academy.Domain.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetAddressByProviderIdAsync(long providerId);
    }
}