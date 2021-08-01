using BIMA.Common.Core.Enum;
using BIMA.Common.EmailService;
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
    public class ContactUsService : IContactUsService

    {
        private readonly IUnitOfWorkAsync<UserQuestionType> _unitOfWork;
        private readonly IEmailSender _emailSender;

        public ContactUsService(IUnitOfWorkAsync<UserQuestionType> unitOfWork,
                                IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public async Task<bool> SendContactUsMessage(ContactUsModel model)
        {
            var users = await _unitOfWork.UserQuestionTypes.GetUserByQuestionType(model.QuestionType);
            if (users.Count == 0 || users == null)
                throw new Exception("Not found users to send message.");

            List<string> usersEmail = new List<string>();
            var content = contactUsContentGenerator(model);

            foreach (var user in users)
                usersEmail.Add(user.User.Email);

            await _emailSender.SendEmailAsync(new Message(usersEmail, "Contact Us Message",
                  content, null));

            return true;
        }

        private string contactUsContentGenerator(ContactUsModel model)
        {
            return $"<p><strong>Name:</strong> {model.Name}<br><strong>Email:</strong> {model.Email}<br><strong>Phone:</strong> {model.Phone}<br><strong>Question Type:</strong> {Enum.GetName(typeof(QuestionType), model.QuestionType)}<br><br><strong>Message:</strong> {model.Message}</p>";
        }
    }
}
