using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BIMA.Domain.Repository.Interfaces
{
    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : class
    {
        IRepositoryAsync<TEntity> Repository { get; }
        int SaveChanges();
        void Dispose(bool disposing);
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}
