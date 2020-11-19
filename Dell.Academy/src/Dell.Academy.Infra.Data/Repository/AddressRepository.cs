using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Dell.Academy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dell.Academy.Infra.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ApiContext context) : base(context)
        {
        }

        public async Task<Address> GetAddressByProviderIdAsync(long providerId)
            => await DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.ProviderId == providerId);
    }
}