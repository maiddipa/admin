using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    public class CourseCategoryController : Controller
    {
        private readonly ICourseCategoryService _courseCategoryService;
        private readonly ILogger<CourseCategoryController> _logger;


        public CourseCategoryController(ICourseCategoryService courseCategoryService,
                               ILogger<CourseCategoryController> logger)
        {
            _courseCategoryService = courseCategoryService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetCourseCategories(CancellationToken cancellationToken)
        {
            var result = await _courseCategoryService.GetCourseCategories(cancellationToken);

            return Ok(result);
        }


        [HttpGet("subcategories")]
        public async Task<IActionResult> GetSubCourseCategories(int courseCategoryId, CancellationToken cancellationToken)
        {
            var result = await _courseCategoryService.GetSubCourseCategories(courseCategoryId, cancellationToken);

            return Ok(result);
        }
    }
}