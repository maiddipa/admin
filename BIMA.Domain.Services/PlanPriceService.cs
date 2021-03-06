using AutoMapper;
using BIMA.Common.Core.Enum;
using BIMA.Database.Entities;
using BIMA.Domain.Models.Public;
using BIMA.Domain.Repository.Interfaces;
using BIMA.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Services
{
    public class PlanPriceService : IPlanPriceService
    {
        private readonly IUnitOfWorkAsync<PlanPrice> _unitOfWork;
        private readonly IMapper _mapper;


        public PlanPriceService(IUnitOfWorkAsync<PlanPrice> unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

      public async Task<PlanPrice> FindById(PlanPricesEnum id)
        {
            return await _unitOfWork.PlanPrices.GetById(id);
        }

    }
}
