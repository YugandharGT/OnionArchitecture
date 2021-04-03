using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorServerApp.Data;
using BlazorServerApp.ClientService;
using System.Net.Http;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using MudBlazor.Services;

namespace BlazorServerApp
{
    public class Startup
    {
        string endpoint = null;

        public Startup()
        {
            #if DEBUG
              endpoint = "http://localhost:4200/";
            #else
                endpoint = "http://localhost:81/";
            #endif
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddMudServices();

            services.AddSingleton<WeatherForecastService>();

            services.AddScoped<HttpClient>();
            

            services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
            {
                client.BaseAddress = new Uri(endpoint);
            });




            //if (services.All(x => x.ServiceType != typeof(HttpClient)))
            //{
            //    services.AddScoped(
            //        s =>
            //        {
            //            var navigationManager = s.GetRequiredService<NavigationManager>();
            //            return new HttpClient
            //            {
            //                BaseAddress = new Uri(navigationManager.BaseUri)
            //            };
            //        });
            //}

            //Blazorise
            services.AddBlazorise(options =>
            {
                options.ChangeTextOnKeyPress = true; // optional
            })
            .AddBootstrapProviders().AddFontAwesomeIcons();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            //Blazorise
            app.ApplicationServices.UseBootstrapProviders().UseFontAwesomeIcons();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
