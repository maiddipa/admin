using BIMA.Database.Entities;
using BIMA.Domain.Models.Public;
using BIMA.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<string> StripePaymentFlow(PaymentModel paymentModel, User user, PlanPrice plan);
        Task<long> GetPaymentIdByChargeId(string chargeId);
    }
}
