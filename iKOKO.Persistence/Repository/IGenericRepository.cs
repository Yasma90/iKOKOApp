using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iKOKO.Persistence.Repository
{
    public interface IGenericRepository<T> where T : class
    {
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