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
    public interface ICourseService
    {
        Task<List<CourseListModel>> GetCoursesByCategoryId(int categoryId, CancellationToken cancellationToken);
        Task<CoursePageModel> GetCourseById(int courseId, int userId, CancellationToken cancellationToken);

    }
}
