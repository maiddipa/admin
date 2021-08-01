using BIMA.Common.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BIMA.Database.Entities
{
    public class Payment
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public string StripeCustomerId { get; set; }
        public string BalanceTransactionId { get; set; }
        public string ChargeId { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public long Amount { get; set; }
        public PlanPricesEnum PlanPrice { get; set; }
    }
}
