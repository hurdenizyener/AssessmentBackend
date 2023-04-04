using Entities.Common;
using System.Linq.Expressions;

namespace DataAccess.Repositories.GenericRepositories.Abstract
{
    public interface IAsyncRepository<T> where T : IEntity
    {

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> AddAsync(T entity);

    }
}
