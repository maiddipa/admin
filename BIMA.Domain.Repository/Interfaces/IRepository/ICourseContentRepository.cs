using BIMA.Common.Core.Enum;
using BIMA.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BIMA.Domain.Repository.Interfaces.IRepository
{
    public interface ICourseContentRepository : IRepositoryAsync<CourseContent>
    {
        Task<List<CourseContent>> GetCourseContentByCourseSectionId(int courseSectionId, CancellationToken cancellationToken);
    }

}
