using BIMA.Domain.Repository.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BIMA.Domain.Repository.Interfaces
{
    public interface IUnitOfWorkAsync<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        IUserRepository Users { get; }
        IUserQuestionTypeRepository UserQuestionTypes { get; }
        INavbarRepository Navbars { get; }
        ICityRepository Cities { get; }
        IPlanPriceRepository PlanPrices { get; }
        IPaymentRepository Payments { get; }
        ICountryRepository Countries { get; }
        ICourseCategoryRepository CourseCategories { get; }
        ICourseRepository Courses { get; }
        ICourseContentRepository CourseContents { get; }
        IUserCourseContentRepository UserCourseContents { get; }


        Task<int> SaveChangesAsync(bool updateEntityLastModifiedField = true);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken, bool updateEntityLastModifiedField = true);
    }
}
