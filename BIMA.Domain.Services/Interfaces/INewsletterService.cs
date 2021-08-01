using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Services.Interfaces
{
    public interface INewsletterService
    {
        Task<bool> SendNewsletter();
        Task<bool> SendEbookMail();
        Task<bool> SendNewsletterWithAttachments(IFormFileCollection files);
    }
}
