using BIMA.Common.EmailService;
using BIMA.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace BIMA.Domain.Service
{
    public class NewsletterService : INewsletterService
    {
        private readonly IEmailSender _emailSender;

        public NewsletterService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }


        public async Task<bool> SendEbookMail()
        {
            var message = new Message(new string[] { "cekic.edin@hotmail.com" }, "Test email async", "Content from test email <h1>helloooooo</h1>", null);
            await _emailSender.SendEBookAsync(message);

            return true;
        }

        public async Task<bool> SendNewsletter()
        {
            var message = new Message(new string[] { "cekic.edin@hotmail.com", "edince@maestralsolutions.com" }, "Test email async", "Content from test email <h1>helloooooo</h1>", null);
            await _emailSender.SendEmailAsync(message);

            return true;
        }

        public async Task<bool> SendNewsletterWithAttachments(IFormFileCollection files)
        {
            var message = new Message(new string[] { "cekic.edin@hotmail.com" }, "Test email async", "Content from test email <h1>helloooooo</h1>", files);
            await _emailSender.SendEmailAsync(message);

            return true;
        }

    }
}
