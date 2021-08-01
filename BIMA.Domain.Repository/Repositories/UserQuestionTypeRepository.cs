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

namespace BIMA.Domain.Repository.Repositories
{
    public class UserQuestionTypeRepository : Repository<UserQuestionType>, IUserQuestionTypeRepository
    {
        private ILogger _logger;

        public UserQuestionTypeRepository(DbContext context, ILogger logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<UserQuestionType>> GetUserByQuestionType(QuestionType type)
        {
                return await BimaDbContext.UserQuestionTypes.Include(x => x.User)
                                                            .Where(x => x.QuestionType == type)
                                                            .AsNoTracking()
                                                            .ToListAsync();
            
        }
    }
}
