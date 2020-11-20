using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Dell.Academy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dell.Academy.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApiContext context) : base(context)
        {
        }

        public async Task<Product> GetProductByProviderIdAsync(long providerId)
            => await DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.ProviderId == providerId);
    }
}