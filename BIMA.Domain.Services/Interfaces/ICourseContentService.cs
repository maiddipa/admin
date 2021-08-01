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
    public interface ICourseContentService
    {
        Task<List<CourseContentModel>> GetCourseContentByCourseSectionId(int courseId, CancellationToken cancellationToken);

    }
}
