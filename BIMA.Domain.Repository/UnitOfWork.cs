using BIMA.Domain.Repository.Repository;
using BIMA.Domain.Repository.Interfaces;
using BIMA.Domain.Repository.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BIMA.Domain.Repository.Repositories;
using BIMA.Database.Entities.BaseEntity;

namespace BIMA.Domain.Repository.Repository
{
    public class UnitOfWork<TEntity> : IUnitOfWorkAsync<TEntity> where TEntity : class
    {
        #region Private Fields
        private bool _disposed;
        private DbContext _dbContext;
        private IDbContextTransaction _transaction;
        private IRepositoryAsync<TEntity> _repository;
        private readonly ILogger<IUnitOfWork<TEntity>> _logger;
        private IUserRepository _users;
        private IUserQuestionTypeRepository _userQuestionTypeRepository;
        private INavbarRepository _navbars;
        private ICityRepository _cities;
        private IPlanPriceRepository _planPrices;
        private IPaymentRepository _payments;
        private ICountryRepository _countries;
        private ICourseCategoryRepository _courseCategories;
        private ICourseRepository _courses;
        private ICourseContentRepository _courseContents;
        private IUserCourseContentRepository _userCourseContents;




        #endregion Private Fields

        public DbContext DbContext
        {
            get { return _dbContext; }
        }

        public IRepositoryAsync<TEntity> Repository => _repository;

        #region Public Repositories
        public IUserRepository Users { get { return _users ?? (_users = new UserRepository(_dbContext, _logger)); } }
        public IUserQuestionTypeRepository UserQuestionTypes { get { return _userQuestionTypeRepository ?? (_userQuestionTypeRepository = new UserQuestionTypeRepository(_dbContext, _logger)); } }
        public INavbarRepository Navbars { get { return _navbars ?? (_navbars = new NavbarRepository(_dbContext, _logger)); } }
        public ICityRepository Cities { get { return _cities ?? (_cities = new CityRepository(_dbContext, _logger)); } }
        public IPlanPriceRepository PlanPrices { get { return _planPrices ?? (_planPrices = new PlanPriceRepository(_dbContext, _logger)); } }
        public IPaymentRepository Payments { get { return _payments ?? (_payments = new PaymentRepository(_dbContext, _logger)); } }
        public ICountryRepository Countries { get { return _countries ?? (_countries = new CountryRepository(_dbContext, _logger)); } }
        public ICourseCategoryRepository CourseCategories { get { return _courseCategories ?? (_courseCategories = new CourseCategoryRepository(_dbContext, _logger)); } }
        public ICourseRepository Courses { get { return _courses ?? (_courses = new CourseRepository(_dbContext, _logger)); } }
        public ICourseContentRepository CourseContents { get { return _courseContents ?? (_courseContents = new CourseContentRepository(_dbContext, _logger)); } }
        public IUserCourseContentRepository UserCourseContents { get { return _userCourseContents ?? (_userCourseContents = new UserCourseContentRepository(_dbContext, _logger)); } }

        #endregion Public Repositories

        #region Constuctor/Dispose


        public UnitOfWork(DbContext dbContext,
                          ILogger<IUnitOfWork<TEntity>> logger)
        {
            _dbContext = dbContext;
            _repository = new Repository<TEntity>(dbContext);
            _logger = logger;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {

                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }

        #endregion Constuctor/Dispose

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(bool updateEntityLastModifiedField = true)
        {
            if (updateEntityLastModifiedField)
                UpdateUpdatedProperty();

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken, bool updateEntityLastModifiedField = true)
        {
            if (updateEntityLastModifiedField)
                UpdateUpdatedProperty();

            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private void UpdateUpdatedProperty()
        {
            var modifiedSourceInfo =
                _dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                if (entry.Entity is BaseEntity entity)
                {
                    entity.LastModified = DateTime.UtcNow;
                }
            }
        }


        #region Unit of Work Transactions

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified)
        {
            if (_dbContext.Database.GetDbConnection().State != ConnectionState.Open)
            {
                _dbContext.Database.GetDbConnection().Open();
            }

            _transaction = _dbContext.Database.BeginTransaction(isolationLevel);
        }

        public bool Commit()
        {
            _transaction.Commit();
            return true;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }


        #endregion
    }
}
