using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logBuilder) =>
            {
                logBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logBuilder.AddConsole();
                logBuilder.AddDebug();
                logBuilder.AddEventSourceLogger();
                logBuilder.AddNLog();
            })
            .UseStartup<Startup>();
    }
}
