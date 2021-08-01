using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIMA.Domain.Models;
using BIMA.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BIMA.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registration")]
        public async Task<bool> UserRegistration(UserRegistrationModel model)
        {
            var result = await _userService.UserRegistration(model);

            return result;
        }
       
    }
}