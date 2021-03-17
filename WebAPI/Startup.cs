using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
        /// <param name="config"></param>
        public Startup(IConfiguration config)
        {
            _config = config;
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

            
            //Framework
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<CoreDbContext>(opt => opt.UseSqlServer(_config.GetConnectionString("CoreDbConnection"), options => options.EnableRetryOnFailure()));

            services.AddSwaggerGen(options =>
            {
                
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "SampleAPI - HTTP API",
                    Version = "v1",
                    Description = "Test HTTP API",
                    
                });
            });
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
            app.UseSwagger()
             .UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
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
