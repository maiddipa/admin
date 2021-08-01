using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Domain.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(params object[] keyValues);
        IEnumerable<TEntity> Where(Func<TEntity, bool> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void AddGraphRange(IEnumerable<TEntity> entities);
        void Modify(TEntity entity);

        void Update(TEntity entity);
        void Remove(object id);
        void RemoveRange(params TEntity[] entities);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
