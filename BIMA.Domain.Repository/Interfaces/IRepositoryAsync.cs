using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BIMA.Domain.Repository.Interfaces
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           List<Expression<Func<TEntity, object>>> includes = null,
           int? page = null,
           int? pageSize = null,
           bool withAsNoTracking = false);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task AddRangeAsync(List<TEntity> objs, CancellationToken cancellationToken);
        IQueryable<TEntity> WhereQ(Expression<Func<TEntity, bool>> predicate);
    }
}
