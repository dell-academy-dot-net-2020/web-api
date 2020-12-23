using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Dell.Academy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.Academy.Infra.Data.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(ApiContext context) : base(context)
        {
        }

        public async Task<Provider> GetProviderWithAddressAndProductsByIdAsync(long id)
            => await DbSet.AsNoTracking().Include(p => p.Address).Include(p => p.Products).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<Provider>> GetProvidersWithAddressAsync()
            => await DbSet.AsNoTracking().Include(p => p.Address).OrderBy(p => p.Name).ToListAsync();

        public async Task<bool> ProviderWithDocumentNumberExistsAsync(string documentNumber)
            => await DbSet.AsNoTracking().AnyAsync(p => p.DocumentNumber == documentNumber);
    }
}