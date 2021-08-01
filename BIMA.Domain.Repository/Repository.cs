using BIMA.Database;
using BIMA.Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BIMA.Domain.Repository.Repository
{
    public class Repository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        #region Private Fields
        public DbContext _dbContext { get; }
        #endregion

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BIMADbContext BimaDbContext
        {
            get
            {
                return _dbContext as BIMADbContext;
            }
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            return _dbContext.Set<TEntity>().Find(keyValues);
        }

        public virtual void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Modify(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public virtual void AddGraphRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public virtual void Remove(object id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            RemoveRange(entity);
        }

        public virtual void RemoveRange(params TEntity[] entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await _dbContext.Set<TEntity>().FindAsync(keyValues);
        }

        public virtual async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return await _dbContext.Set<TEntity>().FindAsync(keyValues, cancellationToken);
        }

        public virtual async Task<bool> DeleteAsync(params object[] keyValues)
        {
            return await DeleteAsync(CancellationToken.None, keyValues);
        }

        public virtual async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var entity = await FindAsync(keyValues);

            if (entity == null)
            {
                throw new Exception("Could not find object");
            }

            _dbContext.Set<TEntity>().Remove(entity);

            return true;
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity != null)
                _dbContext.Set<TEntity>().Remove(entity);
        }

        internal IQueryable<TEntity> Select(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null,
            bool withAsNoTracking = false)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            if (withAsNoTracking) return query.AsNoTracking();

            return query;
        }

        public virtual async Task<IEnumerable<TEntity>> SelectAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null,
            bool withAsNoTracking = false)
        {
            return await Select(filter, orderBy, includes, page, pageSize, withAsNoTracking).ToListAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public IEnumerable<TEntity> Where(Func<TEntity, bool> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> WhereQ(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public async Task AddRangeAsync(List<TEntity> objs, CancellationToken cancellationToken)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(objs, cancellationToken);
        }
    }
}
