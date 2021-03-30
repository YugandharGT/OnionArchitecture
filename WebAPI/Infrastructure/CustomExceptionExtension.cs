using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
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
    public static class CustomExceptionExtension
    {
        #region Custom http pipeline for global exception handling
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomException>();
        }
        #endregion

    }
}
