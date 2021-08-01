using BIMA.Database.Entities;
using BIMA.Domain.Models;
using BIMA.Domain.Repository.Interfaces;
using BIMA.Domain.Repository.Interfaces.IRepository;
using BIMA.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIMA.Domain.Models.User;
using Microsoft.AspNetCore.WebUtilities;
using BIMA.Common.EmailService;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using BIMA.Common.Core.JWTAuth.Interfaces;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using System.Security.Policy;
using Stripe;

namespace BIMA.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<UserService> _logger;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly IUnitOfWorkAsync<User> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPlanPriceService _planPriceService;
        private readonly IPaymentService _paymentService;

        public UserService(UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IEmailSender emailSender,
                              ILogger<UserService> logger,
                              IJwtAuthManager jwtAuthManager,
                              IUnitOfWorkAsync<User> unitOfWork,
                              IMapper mapper,
                              IPlanPriceService planPriceService,
                              IPaymentService paymentService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _jwtAuthManager = jwtAuthManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _planPriceService = planPriceService;
            _paymentService = paymentService;
        }

        public async Task<UserEmailConfirmationModel> UserRegistration(UserRegistrationModel model)
        {

            _logger.LogInformation("User tries to register with email {0}", model.Email);
            var uniqueEmail = await _userManager.FindByEmailAsync(model.Email);
            if (uniqueEmail != null)
            {
                _logger.LogError("Email already exists, {0}", model.Email);
                throw new Exception("Email already exists");
            }

            if (!string.IsNullOrEmpty(model.CompanyUniqueStamp))
                if (!(await CheckDomainMailWithCompanyDomainMail(model.CompanyUniqueStamp, model.Email)))
                    throw new Exception("Please register with company domain mail!");

            if (!string.IsNullOrEmpty(model.CompanyName) && string.IsNullOrEmpty(model.FirstName) && string.IsNullOrEmpty(model.LastName))
                model.CompanyUniqueStamp = Guid.NewGuid().ToString();

                _logger.LogInformation("Mapping user model to entity");
            var user = _mapper.Map<User>(model);

            var result = await _userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.CompanyName) && string.IsNullOrEmpty(model.FirstName) && string.IsNullOrEmpty(model.LastName))
                    await _userManager.AddToRoleAsync(user, "company");
                else
                    await _userManager.AddToRoleAsync(user, "member");

                _logger.LogInformation("User created a new account with password.");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                var callbackUrl = string.Format("user/confirm-email/{0}/{1}", code, user.Email);

                await _emailSender.SendEmailAsync(new Message(new string[] { user.Email }, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.", null));

                 return new UserEmailConfirmationModel(){ Email = user.Email };
            }

            if (result.Errors != null)
            {
                _logger.LogError("{0}", result.Errors);
                throw new Exception("Something went wrong!");
            }

            return new UserEmailConfirmationModel();
        }

        public async Task<LoginResult> UserLogin(UserLoginModel userModel)
        {
            _logger.LogInformation($"User [{userModel.Email}] try to login.");
            var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
            if (result.Succeeded)
            {
                return await TokenGeneratorByUserName(userModel.Email);

            } else
            {
                _logger.LogError($"User [{userModel.Email}] failed to login.");
                throw new Exception("Username or password is incorrect");
            }
        }

        public async Task<bool> UserLogout (string name)
        {
            _jwtAuthManager.RemoveRefreshTokenByUserName(name);
            _logger.LogInformation($"User [{name}] logged out the system.");
            await _signInManager.SignOutAsync();
            return true;
        }

        public async Task<LoginResult> EmailConfirmed(EmailConfirmTokenModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                _logger.LogError("User {0} not found. For email confirmation", model.Email);
                throw new Exception("User not found");
            }

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(model.EmailToken);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);
            var result = await _userManager.ConfirmEmailAsync(user, codeDecoded);
            if (result.Succeeded)
            {
                _logger.LogInformation($"User [{user.UserName}] confirmed email.");
                await _emailSender.SendEBookAsync(new Message(new string[] { user.Email }, "Welcome to digitalBIMAcademy", null, null));
                _logger.LogInformation($"Ebook email is sent to the new user [{user.UserName}]");

                return await TokenGeneratorByUserName(user.UserName);

            } else
            {
                _logger.LogError("{0}", result.Errors);
                throw new Exception("Invalid token");
            }

        }

        public async Task<bool> ForgotPassword(ForgotPasswordModel model)
        {
            _logger.LogInformation("User {0} forgot password", model.Email);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                _logger.LogError("User {0} not found", model.Email);
                return true;
            }

            _logger.LogInformation("User {0} is found and will change password", model.Email);
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = string.Format("user/reset-password/{0}/{1}", code, user.Email);

            await _emailSender.SendEmailAsync(new Message(new string[] { user.Email }, "Forgot password",
                $"To reset your password, please <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>click here</a>.", null));

            return true;
        }

        public async Task<bool> ResetPassword(ResetPasswordModel model)
        {
            _logger.LogInformation("User {0} reset password", model.Email);
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                _logger.LogError("User {0} reset password not found", model.Email);
                throw new Exception("User not found.");
            }

            var resetPassResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (resetPassResult.Succeeded)
            {
                _logger.LogInformation("User {0} reset password succeedded", model.Email);
                return resetPassResult.Succeeded;
            }
            else
            {
                _logger.LogInformation("User {0} reset password failed", model.Email);
                throw new Exception("Something went wrong.");
            }

        }

        public async Task<bool> UserPayment(PaymentModel paymentModel)
        {
            _logger.LogInformation("User with id {0}, try payment", paymentModel.UserId);
            var user = await _userManager.FindByIdAsync(paymentModel.UserId.ToString());
            if (user == null)
            {
                _logger.LogError("User with ID {0} not found", paymentModel.UserId);
                throw new Exception("User not found!");
            };

            var plan = await _planPriceService.FindById(paymentModel.PlanPrice);
            if (plan == null)
            {
                _logger.LogError("Plan price with ID {0} not found", paymentModel.PlanPrice);
                throw new Exception("Plan price not found!");
            };

            var chargeId = await _paymentService.StripePaymentFlow(paymentModel, user, plan);

            _logger.LogInformation("Get new payment for user with charge Id {0}", chargeId);
            var paymentId = await _paymentService.GetPaymentIdByChargeId(chargeId);
            if (paymentId == 0)
            {
                _logger.LogError("Payment with charge ID {0} not found", chargeId);
                throw new Exception("Payment not found!");
            };
            user.Paid = true;

            var updated = await _userManager.UpdateAsync(user);
            if (updated.Succeeded)
            {
                _logger.LogInformation("User successfully paid, payment ID {0}", paymentId);
                return updated.Succeeded;
            }
            else
                throw new Exception("Something went wrong in payment or user update");


        }

        private async Task<bool> CheckDomainMailWithCompanyDomainMail(string companyUniqueStamp, string employeeEmail)
        {
            var company = await _unitOfWork.Users.GetByCompanyUniqueStamp(companyUniqueStamp);
            var companyDomainMail = company.Email.Substring(company.Email.IndexOf("@"));
            var userDomainMail = employeeEmail.Substring(employeeEmail.IndexOf("@"));

            return userDomainMail.Equals(companyDomainMail);
            
        }

        private async Task<LoginResult> TokenGeneratorByUserName(string username)
        {
            _logger.LogInformation("User {0} generate token by username", username);
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                _logger.LogError("User {0} reset password not found", username);
                throw new Exception("User not found.");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var jwtResult = _jwtAuthManager.GenerateTokens(user.UserName, claims, DateTime.Now);
            _logger.LogInformation($"User [{user.UserName}] logged in the system.");
            return new LoginResult
            {
                UserName = user.UserName,
                Roles = roles,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            };
        }

       

    }
}
