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
using OA.Concrete;
using OA.Data.Context;
using OA.Interface;
using OA.Repo;

namespace WebAPI
{
    public class Startup
    {
        IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMemoryCache();
            //services.AddSession();

            services.AddSwaggerGen(s => { 
            });
            //Framework
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<CoreDbContext>(opt => opt.UseSqlServer(_config.GetConnectionString("CoreDbConnection"), options => options.EnableRetryOnFailure()));

            //DI
            services.AddScoped<IEmployeeTaskRepository, EmployeeTaskRepository>();
            //services.AddLogging();

            //services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
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
            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
