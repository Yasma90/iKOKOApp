﻿using System;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace iKOKO.Persistence.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>, IDisposable
        where TEntity : class
    {

        private readonly iKOKODbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private bool disposed;

        public GenericRepository(iKOKODbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public Task<IList<TEntity>> Get(Expression<Func<TEntity, bool>> expression = null, IList<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, IList<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }
        
        public async Task<TEntity> GetAsync(Guid id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }
        
        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            return entities;
        }

        public async Task<TEntity> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
            return entity;
        }

        public IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            return entities;
        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposed = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~GenericRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
     
        #endregion

    }
}
