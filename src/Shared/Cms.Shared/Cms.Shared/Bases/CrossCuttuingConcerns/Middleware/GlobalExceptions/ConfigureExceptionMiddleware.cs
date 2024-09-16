﻿using Microsoft.AspNetCore.Builder;

namespace Cms.Shared.Bases.CrossCuttuingConcerns.Middleware.GlobalExceptions
{
    public static class ConfigureExceptionMiddleware
    {
        public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
