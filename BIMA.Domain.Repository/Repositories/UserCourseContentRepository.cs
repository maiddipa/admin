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
using System.Threading.Tasks;

namespace BIMA.Domain.Repository
{
    public class UserCourseContentRepository : Repository<UserCourseContent>, IUserCourseContentRepository
    {
        private ILogger _logger;

        public UserCourseContentRepository(DbContext context, ILogger logger) : base(context)
        {
            _logger = logger;
        }


        public async Task<List<UserCourseContent>> GetByUserIdAndCourseContentIds(int userId, int courseId)
        {
            return await BimaDbContext.UserCourseContents.Include(x => x.CourseContent)
                                                         .Where(x => x.UserId == userId && x.CourseId == courseId)
                                                         .AsNoTracking()
                                                         .ToListAsync();
        }

    }
}
