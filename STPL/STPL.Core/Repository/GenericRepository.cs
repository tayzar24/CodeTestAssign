using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using STPL.Common.Model;
using STPL.Core.IRepository;
using STPL.Core.Model;
using STPL.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using STPL.Entity;

namespace STPL.Core.Repository
{
    public class GenericRepository<T> : Disposable, IGenericRepository<T> where T : class
    {
        protected readonly STPLContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(STPLContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            T entityData = _context.Set<T>().Add(entity).Entity;
            return entityData;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsQueryable().AsNoTracking();
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public virtual async Task<ResultData<T>> GetAllListAsync(PageInfo page)
        {
            return await _context.Set<T>().FilterGrid(page);
        }

        public virtual async Task<ResultData<T>> GetAllListAsync(Expression<Func<T, bool>> expression, PageInfo page)
        {
            IQueryable<T> result = _context.Set<T>().Where(expression).AsQueryable().AsNoTracking();
            return await result.FilterGrid(page);
        }

        public async virtual Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().AddRange(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<T> Update(T entity)
        {
            T entityData = _context.Set<T>().Update(entity).Entity;
            _context.Entry(entity).State = EntityState.Modified;
            return entityData;
        }
        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public IQueryable<T> Include(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.Where(whereClause);

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public T FindWithIncludedEntities(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.Where(predicate);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefault();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
