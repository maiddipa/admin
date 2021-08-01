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
    public class NavbarRepository : Repository<Navbar>, INavbarRepository
    {
        private ILogger _logger;

        public NavbarRepository(DbContext context, ILogger logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<List<Navbar>> GetNavbarsByLanguageId(int langId)
        {
            return await BimaDbContext.Navbars.Where(x => x.LanguageId == langId)
                                            .OrderBy(x => x.Order)
                                            .AsNoTracking()
                                            .ToListAsync();

        }
    }
}
