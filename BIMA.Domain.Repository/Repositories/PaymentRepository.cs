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
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        private ILogger _logger;

        public PaymentRepository(DbContext context, ILogger logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<long> GetPaymentIdByChargeId(string chargeId)
        {
            return await BimaDbContext.Payments.Where(x => x.ChargeId == chargeId)
                                               .AsNoTracking()
                                               .Select(x => x.Id)
                                               .FirstOrDefaultAsync();
        }
        public async Task<Payment> GetPaymentByUserId(long userId)
        {
            return await BimaDbContext.Payments.Where(x => x.UserId == userId)
                                               .AsNoTracking()
                                               .FirstOrDefaultAsync();
        }
    }
}
