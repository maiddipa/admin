using BIMA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> UserRegistration(UserRegistrationModel userModel);
    }
}
