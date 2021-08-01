using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BIMA.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {


        public AdminController()
        {

        }


        [HttpGet("allow-administration")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<ActionResult> Administration()
        {
            try
            {
               
                return Ok();
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }
    }
}