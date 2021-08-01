using BIMA.Domain.Models.Public;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Services.Interfaces
{
    public interface IContactUsService
    {
        Task<bool> SendContactUsMessage(ContactUsModel model);
    }
}
