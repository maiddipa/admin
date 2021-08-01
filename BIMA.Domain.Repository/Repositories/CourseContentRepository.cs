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
    public class CourseContentRepository : Repository<CourseContent>, ICourseContentRepository
    {
        private ILogger _logger;

        public CourseContentRepository(DbContext context, ILogger logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<CourseContent>> GetCourseContentByCourseSectionId(int courseSectionId, CancellationToken cancellationToken)
        {
            return await BimaDbContext.CourseContents.Where(x => x.CourseSectionId == courseSectionId)
                                                     .OrderBy(x => x.Order)
                                                     .AsNoTracking()
                                                     .ToListAsync(cancellationToken);
        }

    }
}
