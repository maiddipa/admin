using BIMA.Domain.Models.Public;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Services.Interfaces
{
    public interface INavbarService
    {
        Task<List<NavbarModel>> GetNavbarItems(int? langId);
    }
}
