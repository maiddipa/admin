using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BIMA.Common.EmailService;
using BIMA.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BIMA.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICourseContentService _courseContentService;
        private readonly ILogger<CourseController> _logger;


        public CourseController(ICourseService courseService,
                                ICourseContentService courseContentService,
                                ILogger<CourseController> logger)
        {
            _courseService = courseService;
            _logger = logger;
            _courseContentService = courseContentService;
        }


        [HttpGet("courses")]
        public async Task<IActionResult> GetCoursesByCategoryId(int categoryId, CancellationToken cancellationToken)
        {
            var result = await _courseService.GetCoursesByCategoryId(categoryId, cancellationToken);

            return Ok(result);
        }

        [HttpGet("course/{courseId}/{userId}")]
        public async Task<IActionResult> GetCourseByCourseIdAndUserId([FromRoute]int courseId, [FromRoute] int userId, CancellationToken cancellationToken)
        {
            var result = await _courseService.GetCourseById(courseId, userId, cancellationToken);
            return Ok(result);
        }
    }
}