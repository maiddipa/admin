using BIMA.Common.Core.Enum;
using BIMA.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BIMA.Domain.Repository.Interfaces.IRepository
{
    public interface ICourseCategoryRepository : IRepositoryAsync<CourseCategory>
    {
        Task<List<CourseCategory>> GetCourseCategories(CancellationToken cancellationToken);
        Task<List<CourseCategory>> GetCourseCategoriesByParentCategoryId(int courseCategoryId, CancellationToken cancellationToken);
    }

}
