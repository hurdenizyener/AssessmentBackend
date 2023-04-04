using DataAccess.Repositories.GenericRepositories.Abstract;
using Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories.GenericRepositories
{
    public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext
    {
        protected TContext Context { get; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate != null ? await Context.Set<TEntity>().Where(predicate).ToListAsync() : await Context.Set<TEntity>().ToListAsync();
        }

    }
}
