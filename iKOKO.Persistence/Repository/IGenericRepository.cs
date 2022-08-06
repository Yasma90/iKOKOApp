using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace iKOKO.Persistence.Repository
{
    public interface IGenericRepository<T> where T : class//, IDisposable
    {
        Task<IList<T>> Get(Expression<Func<T, bool>> expression = null, IList<string> includes = null);
        Task<IList<T>> GetAll(
            Expression<Func<T,bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            IList<string> includes = null );
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Guid Id);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        Task<T> DeleteAsync(Guid id);
        IEnumerable<T> DeleteRange(IEnumerable<T> entities);
    }
}