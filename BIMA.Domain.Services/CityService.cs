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
    public class CityService : ICityService
    {
        private readonly IUnitOfWorkAsync<City> _unitOfWork;
        private readonly IMapper _mapper;


        public CityService(IUnitOfWorkAsync<City> unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

      public async Task<List<CityModel>> FindCitiesByCountryCode(string countryCode)
        {
            var cities =  await _unitOfWork.Cities.SearchCitiesByCountryCode(countryCode);
            var mapped = _mapper.Map<List<CityModel>>(cities);

            return mapped;
        }

    }
}
