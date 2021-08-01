using BIMA.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Repository.Interfaces.IRepository
{
    public interface IUserRepository : IRepositoryAsync<User>
    {
        Task<User> GetByCompanyUniqueStamp(string companyUniqueStamp);
    }

}
