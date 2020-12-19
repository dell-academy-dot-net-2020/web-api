using Dell.Academy.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProductByIdWithCategoryAndProviderAsync(long id);

        Task<List<Product>> GetProductsByProviderIdAsync(long providerId);

        Task<List<Product>> GetProductsWithCategoryAndProviderAsync();

        Task<bool> ProductSkuExists(Product product);
    }
}