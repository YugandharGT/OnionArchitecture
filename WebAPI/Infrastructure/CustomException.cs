using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomException
    {

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        public CustomException(RequestDelegate next, ILogger logger)
        {
            _logger = logger;
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from the custom middleware."
            }.ToString());
        }
    }
}
