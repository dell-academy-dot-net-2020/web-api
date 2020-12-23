using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Dell.Academy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dell.Academy.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApiContext context) : base(context)
        {
        }

        public async Task<Product> GetProductByIdWithCategoryAndProviderAsync(long id)
            => await DbSet.AsNoTracking().Include(p => p.Category).Include(p => p.Provider).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<Product>> GetProductsByProviderIdAsync(long providerId)
            => await DbSet.AsNoTracking().Where(p => p.ProviderId == providerId).ToListAsync();

        public async Task<List<Product>> GetProductsWithCategoryAndProviderAsync()
            => await DbSet.AsNoTracking().Include(p => p.Category).Include(p => p.Provider).OrderBy(x => x.Name).ToListAsync();

        public async Task<bool> ProductSkuExists(Product product) => await DbSet.AsNoTracking().AnyAsync(p => p.Sku == product.Sku && p.Id != product.Id);
    }
}