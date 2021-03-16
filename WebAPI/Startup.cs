using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OA.Concrete;
using OA.Data.Context;
using OA.Interface;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.Swagger;
using System;
using Microsoft.OpenApi.Models;

namespace WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        IConfiguration _config;
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public Startup(IConfiguration config)
        {
            _config = config;
            
        }

        //Uncomment for development mode
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
#if DEBUG
            //Loads file from hosting environment path
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();
            Configuration = builder.Build();
#endif
        }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Load configuration data from settings files
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
            //    .AddEnvironmentVariables();
            //_config = builder.Build();

            //Framework
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<CoreDbContext>(opt => opt.UseSqlServer(_config.GetConnectionString("CoreDbConnection"), options => options.EnableRetryOnFailure()));

            ConfigureContractImplementations(services);
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo ()
                {
                    Title = "Practise - My HTTP API",
                    Version = "v1",
                    Description = "The Catalog Microservice HTTP API",
                    
                });
            });

            //services.AddSwaggerGen(s => {
            //    s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Generic Core Web API", Description = "Swagger for Core API" });

            //    var xmlPath = string.Join("", new string[] { System.AppDomain.CurrentDomain.BaseDirectory, "WebAPI.xml" });
            //    s.IncludeXmlComments(xmlPath);
            //});
        }

        private void ConfigureContractImplementations(IServiceCollection services)
        {
            //LoadSettings
            //services.Configure<AppSettings>(_config.GetSection("{sectionname in json config file}"));

            //DLL References
            //services.Configure<DLLReference>(_config.GetSection("{DLL sectionname in json config file}"));
            //services.AddTransient<Reference_Interface, Reference_Concrete>();

            //services.AddLogging();

            ConfigureSwagger(services);

            ConfigureObjects(services);

            //Uncomment for within IIS deployment
#if RELEASE
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });
#endif
        }

        /// <summary>
        /// DI
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureObjects(IServiceCollection services)
        {
            services.AddScoped<IEmployeeTaskRepository, EmployeeTaskRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger()
           .UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint($"/swagger/v1/swagger.json", "MyApi V1");

           });
            //loggerFactory.AddFile("Logs/CoreApp_{Date}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseMvc();

        }
        //string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
       
    }

    internal class AppSettings
    {
    }
}
