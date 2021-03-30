using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());          
        }
    }
}
