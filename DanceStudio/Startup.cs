using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceStudio.Data;
using DanceStudio.Services.Coaches;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DanceStudio
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DanceStudioContext>(options => { options.UseSqlite("Filename=danceStudio.db"); });
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddScoped<CoachService>();
            services.AddScoped<ICoachRepository, CoachRepository>();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DanceStudioContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                /*routes.MapRoute(
                    name: "calculator",
                    template: "Calculator/{action}/{number:int}",
                    defaults: new { Controller = "Calculator" });

                routes.MapRoute(
                    name: "messages",
                    template: "say/{**message}",
                    defaults: new { controller="Messages", action = "ShowMessage" }); */

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Main}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();
        }
    }
}