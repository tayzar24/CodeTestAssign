using Microsoft.EntityFrameworkCore.Storage;
using STPL.Common.Model;
using STPL.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace STPL.Core.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string id);

        Task<IEnumerable<T>> GetAllAsync();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        Task<ResultData<T>> GetAllListAsync(PageInfo page);

        Task<ResultData<T>> GetAllListAsync(Expression<Func<T, bool>> expression, PageInfo page);

        Task<T> Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task<T> Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
        IQueryable<T> Include(Expression<Func<T, bool>> whereClause, params Expression<Func<T, object>>[] includes);

        T FindWithIncludedEntities(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        int Commit();
        IDbContextTransaction BeginTransaction();
    }
}
