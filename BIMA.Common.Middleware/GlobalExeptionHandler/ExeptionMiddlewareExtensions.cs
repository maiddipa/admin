﻿using Microsoft.AspNetCore.Builder;

namespace BIMA.Common.Middleware.GlobalExeptionHandler
{
    public static class ExeptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
