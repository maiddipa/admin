using BIMA.Common.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIMA.Domain.Models.User
{
    public class PaymentModel
    {
        public int UserId { get; set; }
        public PlanPricesEnum PlanPrice { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string CVC { get; set; }
    }
}
