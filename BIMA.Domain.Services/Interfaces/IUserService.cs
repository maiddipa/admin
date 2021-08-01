using BIMA.Domain.Models;
using BIMA.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BIMA.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserEmailConfirmationModel> UserRegistration(UserRegistrationModel userModel);
        Task<LoginResult> UserLogin(UserLoginModel userModel);
        Task<bool> UserLogout(string name);
        Task<LoginResult> EmailConfirmed(EmailConfirmTokenModel model);
        Task<bool> ForgotPassword(ForgotPasswordModel model);
        Task<bool> ResetPassword(ResetPasswordModel model);
        Task<bool> UserPayment(PaymentModel model);
    }
}
