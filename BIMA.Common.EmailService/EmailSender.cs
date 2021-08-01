using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Common.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }


        public async Task SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);

            await SendAsync(mailMessage);
        }

        public async Task SendEBookAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message, true);

            await SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message, bool ebook = false)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<p>{0}<p>", message.Content) };

            if (ebook)
                emailMessage.Body = AddEBookAttachment(bodyBuilder).ToMessageBody();
            else if (message.Attachments != null && message.Attachments.Any() && !ebook)
                emailMessage.Body = LoadAttachments(message, bodyBuilder).ToMessageBody();
            else
                emailMessage.Body = bodyBuilder.ToMessageBody();


            return emailMessage;
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(mailMessage);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        private BodyBuilder LoadAttachments(Message message, BodyBuilder bodyBuilder)
        {
            AddAttachments(message, bodyBuilder);

            return bodyBuilder;
        }

        private BodyBuilder AddAttachments(Message message, BodyBuilder bodyBuilder)
        {
            byte[] fileBytes;
            foreach (var attachment in message.Attachments)
            {
                using (var ms = new MemoryStream())
                {
                    attachment.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }

                bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
            }
            return bodyBuilder;
        }

        private BodyBuilder AddEBookAttachment(BodyBuilder bodyBuilder)
        {
            byte[] fileBytes;
            string pdfPath = @"..\BIMA.Common.EmailService\E-book\e-book.pdf";
            fileBytes = File.ReadAllBytes(pdfPath);
            
            bodyBuilder.Attachments.Add("e-book.pdf", fileBytes, ContentType.Parse("application/pdf"));

            return bodyBuilder;
        }
    }
}
