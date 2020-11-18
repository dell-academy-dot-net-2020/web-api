using Dell.Academy.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(long id);

        Task<bool> InsertAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(long id);

        Task<bool> SaveChangesAsync();
    }
}