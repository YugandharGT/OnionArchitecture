using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logBuilder) =>
            {
                logBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                //logBuilder.AddEventLog(new EventLogSettings()
                //{
                //    SourceName = "HappyCoderScoure",
                //    LogName = "HappyApplication",
                //    Filter = (x, y) => y >= LogLevel.Information
                //});
                logBuilder.AddConsole();
                logBuilder.AddDebug();
                logBuilder.AddEventSourceLogger();
                logBuilder.AddNLog();

                logBuilder.SetMinimumLevel(LogLevel.Warning);
            })
            //Uncomment for within IIS deployment
#if RELEASE
            .UseKestrel()
            .UseContentRoot(System.IO.Directory.GetCurrentDirectory())
            .UseIIS()
#endif


            .UseStartup<Startup>();
    }
}
