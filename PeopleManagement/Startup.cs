using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PeopleManagement.Data;
using PeopleManagement.Data.Entities;
using PeopleManagement.Services;

namespace PeopleManagement
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PeopleContext>(cfg=>
            {
                cfg.UseSqlServer(_config.GetConnectionString("PeopleConnectionString"));
                });
            services.AddTransient<PeopleSeeder>();
            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            app.UseStaticFiles();
            app.UseNodeModules();
            app.UseRouting();
            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Fallback",
                    "{controller}/{action}/{id?}",
                 new { controller = "People", action = "Index" });
            });

        }
    }
}
