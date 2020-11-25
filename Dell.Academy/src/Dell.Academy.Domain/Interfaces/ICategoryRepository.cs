using Dell.Academy.Domain.Models;
using System.Threading.Tasks;

namespace Dell.Academy.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryWithAllProductsByIdAsync(long id);

        Task<bool> CategoryWithNameExistsAsync(string name);
    }
}