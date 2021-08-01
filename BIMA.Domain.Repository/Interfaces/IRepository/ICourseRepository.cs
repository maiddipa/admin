using BIMA.Common.Core.Enum;
using BIMA.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BIMA.Domain.Repository.Interfaces.IRepository
{
    public interface ICourseRepository : IRepositoryAsync<Course>
    {
        Task<List<Course>> GetCoursesByCategoryId(int categoryId, CancellationToken cancellationToken);
        Task<Course> GetCourseById(int courseId, CancellationToken cancellationToken);

    }

}
