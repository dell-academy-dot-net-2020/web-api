using Dell.Academy.Domain.Interfaces;
using Dell.Academy.Domain.Models;
using Dell.Academy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dell.Academy.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly ApiContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ApiContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync() => await DbSet.AsNoTracking().ToListAsync();

        public async Task<TEntity> GetByIdAsync(long id) => await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<bool> InsertAsync(TEntity entity)
        {
            DbSet.Add(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            return await SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            DbSet.Remove(new TEntity() { Id = id });
            return await SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync() => await Context.SaveChangesAsync() > 0;
    }
}