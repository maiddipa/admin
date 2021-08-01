using AutoMapper;
using BIMA.Common.Core.Enum;
using BIMA.Database.Entities;
using BIMA.Domain.Models.Public;
using BIMA.Domain.Repository.Interfaces;
using BIMA.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BIMA.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWorkAsync<Country> _unitOfWork;
        private readonly IMapper _mapper;


        public CountryService(IUnitOfWorkAsync<Country> unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CountryModel>> GetCountries(CancellationToken cancellationToken)
        {
            var countries = await _unitOfWork.Countries.GetAllAsync(cancellationToken);
            var mapped = _mapper.Map<List<CountryModel>>(countries);

            return mapped;
        }

    }
}
