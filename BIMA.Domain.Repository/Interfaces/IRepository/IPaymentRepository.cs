using BIMA.Common.Core.Enum;
using BIMA.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Repository.Interfaces.IRepository
{
    public interface IPaymentRepository : IRepositoryAsync<Payment>
    {
        Task<long> GetPaymentIdByChargeId(string chargeId);
        Task<Payment> GetPaymentByUserId(long userId);
    }

}
