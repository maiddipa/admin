using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIMA.Common.Core.JWTAuth.Interfaces;
using BIMA.Domain.Models;
using BIMA.Domain.Models.User;
using BIMA.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace BIMA.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;


        public UserController(IUserService userService,
                              IJwtAuthManager jwtAuthManager)
        {
            _userService = userService;
            _jwtAuthManager = jwtAuthManager;
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        public async Task<IActionResult> UserRegistration(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _userService.UserRegistration(model);
                    return Ok(result);
                } catch (Exception e)
                {
                    return BadRequest(e);
                }
               
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogin(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _userService.UserLogin(model);
                if (response == null)
                    return BadRequest(new { message = "Username or password is incorrect" });
                return Ok(response);
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            var name = HttpContext.User.Identity.Name;
            var result = await _userService.UserLogout(name);
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        [Authorize]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var name = HttpContext.User.Identity.Name;
                var accessToken = await HttpContext.GetTokenAsync("Bearer", "access_token");
                var result = _jwtAuthManager.Refresh(request.RefreshToken, accessToken, DateTime.Now);

                return Ok(result);
            }
            catch (SecurityTokenException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPost("email-confirmed")]
        public async Task<IActionResult> EmailConfirmed([FromBody] EmailConfirmTokenModel model)
        {
            var result = await _userService.EmailConfirmed(model);
                return Ok(result);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            var result = await _userService.ForgotPassword(model);
            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            var result = await _userService.ResetPassword(model);
            return Ok(result);
        }

        [HttpPost("payment")]
        public async Task<IActionResult> UserPayment([FromBody] PaymentModel model)
        {
            var result = await _userService.UserPayment(model);
            return Ok(result);
        }
    }
}