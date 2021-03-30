using System; 
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using OA.Concrete;
using OA.Data.Context;
using OA.Interface;
using OA.Repo;
using WebAPI.Infrastructure;


namespace WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        readonly IConfiguration _config;
        private readonly ILogger _logger = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        /// <param name="logger"></param>
        public Startup(IConfiguration config, ILogger<Startup> logger)
        {
            _config = config;
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMemoryCache();
            //services.AddSession();

            //Register Logging
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Startup>>();
            services.AddSingleton(typeof(ILogger), logger);

            //Register all Repository implementation
            services.AddApplication();

            //Framework
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<CoreDbContext>(opt => opt.UseSqlServer(_config.GetConnectionString("CoreDbConnection"), options => options.EnableRetryOnFailure()));

            

            #region Swagger
            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(string.Format(@"{0}\WebApi.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "SampleAPI - HTTP API",
                    Version = "v1",
                    Description = "Test HTTP API",

                });
            });
            #endregion


            #region API Versioning
            // Add API Versioning to the Project
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
            #endregion
            //DI
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddScoped<IEmployeeTaskRepository, EmployeeTaskRepository>();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //global error handling
            app.ConfigureCustomExceptionMiddleware();
            ////overriding to get technical details
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        _logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
            app.UseSwagger()
             .UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
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
    }
}
