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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DanceStudio
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityResult roleResult;
            //Adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            IdentityUser user = await UserManager.FindByEmailAsync("admin@email.com");
            await UserManager.AddToRoleAsync(user, "Admin");
        }

        
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DanceStudioContext>(options =>
            {
                options.UseSqlite("Filename=danceStudio.db");
            });
            
            services.AddMvc(option => option.EnableEndpointRouting = false); 
            services.AddScoped<CoachService>();
            services.AddScoped<ICoachRepository, CoachRepository>();
            
            // identity
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DanceStudioContext>();
            
            services.AddControllersWithViews();
            services.AddRazorPages();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            
            
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Main}/{action=Index}/{id?}");
            });
            
            CreateUserRoles(serviceProvider).Wait();
            

            app.UseStaticFiles();
            
            app.UseHttpsRedirection();

            app.UseRouting();

        }
    }
}