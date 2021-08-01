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
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private ILogger _logger;

        public CountryRepository(DbContext context, ILogger logger) : base(context)
        {
            _logger = logger;
        }

       
    }
}
