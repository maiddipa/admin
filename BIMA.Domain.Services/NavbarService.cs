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
    public class NavbarService : INavbarService
    {
        private readonly IUnitOfWorkAsync<Navbar> _unitOfWork;
        private readonly IMapper _mapper;


        public NavbarService(IUnitOfWorkAsync<Navbar> unitOfWork,
                                  IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<NavbarModel>> GetNavbarItems(int? langId)
        {
            if (!langId.HasValue)
                langId = 1;

            var navbarList = await _unitOfWork.Navbars.GetNavbarsByLanguageId(langId.Value);
            if (navbarList == null || navbarList.Count == 0)
                throw new Exception("Something went wrong");

            var mapped = _mapper.Map<List<NavbarModel>>(navbarList);

            return mapped;
        }

      
    }
}
