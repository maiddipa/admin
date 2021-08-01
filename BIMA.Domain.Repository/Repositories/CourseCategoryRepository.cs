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
    public class CourseCategoryRepository : Repository<CourseCategory>, ICourseCategoryRepository
    {
        private ILogger _logger;

        public CourseCategoryRepository(DbContext context, ILogger logger) : base(context)
        {
            _logger = logger;
        }


        public async Task<List<CourseCategory>> GetCourseCategories(CancellationToken cancellationToken)
        {
            return await BimaDbContext.CourseCategories.Where(x => !x.ParentCategoryId.HasValue)
                                                       .OrderBy(x => x.Order)
                                                       .AsNoTracking()
                                                       .ToListAsync(cancellationToken);
        }

        public async Task<List<CourseCategory>> GetCourseCategoriesByParentCategoryId(int courseCategoryId, CancellationToken cancellationToken)
        {
            return await BimaDbContext.CourseCategories.Where(x => x.ParentCategoryId.HasValue && x.ParentCategoryId == courseCategoryId)
                                                       .OrderBy(x => x.Order)
                                                       .AsNoTracking()
                                                       .ToListAsync(cancellationToken);
        }
    }
}
