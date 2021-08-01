using BIMA.Common.Core.Enum;
using BIMA.Database.Entities;
using BIMA.Domain.Models.Public;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Services.Interfaces
{
    public interface IPlanPriceService
    {
        Task<PlanPrice> FindById(PlanPricesEnum id);
    }
}
