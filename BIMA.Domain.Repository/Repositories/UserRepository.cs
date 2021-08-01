using BIMA.Database;
using BIMA.Database.Entities;
using BIMA.Domain.Repository.Interfaces.IRepository;
using BIMA.Domain.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ILogger _logger;

        public UserRepository(DbContext context, ILogger logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<User> GetByCompanyUniqueStamp(string companyUniqueStamp)
        {
            return await BimaDbContext.Users.AsNoTracking()
                                            .FirstOrDefaultAsync(x => x.CompanyUniqueStamp.Equals(companyUniqueStamp));
        }

    }
}
