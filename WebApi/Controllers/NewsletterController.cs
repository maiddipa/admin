using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIMA.Common.EmailService;
using BIMA.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BIMA.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;
        private readonly ILogger<NewsletterController> _logger;


        public NewsletterController(INewsletterService newsletterService,
                               ILogger<NewsletterController> logger)
        {
            _newsletterService = newsletterService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> SendNewsletter()
        {
            var result = await _newsletterService.SendNewsletter();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SendNewsletterWithAttachments()
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            var result = await _newsletterService.SendNewsletterWithAttachments(files);

            return Ok(result);
        }
    }
}