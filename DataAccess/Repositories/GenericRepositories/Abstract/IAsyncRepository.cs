using Entities.Common;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Repositories.GenericRepositories.Abstract
{
    public interface IAsyncRepository<T> where T : IEntity
    {

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);

    }
}
