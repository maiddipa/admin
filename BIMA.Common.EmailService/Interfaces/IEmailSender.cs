using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Common.EmailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
        Task SendEBookAsync(Message message);
    }
}
