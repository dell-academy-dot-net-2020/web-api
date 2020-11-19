using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Dell.Academy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Dell.Academy.Infra.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApiContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryWithAllProductsByIdAsync(long id)
            => await DbSet.AsNoTracking().Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
    }
}