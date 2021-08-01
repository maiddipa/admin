using BIMA.Database.Entities;
using BIMA.Domain.Models.Course;
using BIMA.Domain.Models.Public;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BIMA.Domain.Services.Interfaces
{
    public interface ICourseCategoryService
    {
        Task<List<CourseCategoryModel>> GetCourseCategories(CancellationToken cancellationToken);

        Task<List<CourseCategoryModel>> GetSubCourseCategories(int courseCategoryId, CancellationToken cancellationToken);
    }
}
