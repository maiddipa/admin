using BIMA.Common.Core.Enum;
using BIMA.Database;
using BIMA.Database.Entities;
using BIMA.Domain.Repository.Interfaces.IRepository;
using BIMA.Domain.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BIMA.Domain.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private ILogger _logger;

        public CourseRepository(DbContext context, ILogger logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<Course>> GetCoursesByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            return await BimaDbContext.Courses.Where(x => x.CourseCategoryId == categoryId)
                                              .OrderBy(x => x.Order)
                                              .AsNoTracking()
                                              .ToListAsync(cancellationToken);
        }

        public async Task<Course> GetCourseById(int id, CancellationToken cancellationToken)
        {
            return await BimaDbContext.Courses.Include(x => x.CourseSections)
                                                 .ThenInclude(x => x.CourseContents)
                                              .Where(x => x.Id == id)
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync(cancellationToken);
        }

    }
}
