using BIMA.Common.Core.Enum;
using BIMA.Domain.Models.Public;
using BIMA.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BIMA.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublicController : Controller
    {
        private readonly IContactUsService _contactusService;
        private readonly INavbarService _navbarService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public PublicController(IContactUsService contactusService,
                                INavbarService navbarService,
                                ICityService cityService,
                                ICountryService countryService)
        {
            _contactusService = contactusService;
            _navbarService = navbarService;
            _cityService = cityService;
            _countryService = countryService;

        }

        [HttpPost("contact-us")]
        [AllowAnonymous]
        public async Task<IActionResult> UserRegistration(ContactUsModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _contactusService.SendContactUsMessage(model);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("navbar")]
        [AllowAnonymous]
        public async Task<IActionResult> NavbarItems(int? langId)
        {

            var result = await _navbarService.GetNavbarItems(langId);
            return Ok(result);
        }

        [HttpGet("find-city")]
        [AllowAnonymous]
        public async Task<IActionResult> FindCity(string countryCode)
        {
            var result = await _cityService.FindCitiesByCountryCode(countryCode);
            return Ok(result);
        }

        [HttpGet("countries")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCountries(CancellationToken cancellationToken)
        {
            var result = await _countryService.GetCountries(cancellationToken);
            return Ok(result);
        }

        [HttpGet("navbar-dropdown")]
        [Authorize]
        public async Task<IActionResult> GetNavbarDropdown(CancellationToken cancellationToken)
        {
            var result = await _countryService.GetCountries(cancellationToken);
            return Ok(result);
        }
    }
}
