using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using AspNetCoreFromCli.Services;
using AspNetCoreFromCli.Models;
using AspNetCoreFromCli.Data;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreFromCli
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            string ss= configuration["ConnectionStrings:DefaultConnection"];
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(MvcOptions => {
                MvcOptions.EnableEndpointRouting = false;
            });
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]); //.GetConnectionString("DefaultConnection")
            });
            services.AddSingleton<IWelComeServices, WelComeServices>();
            services.AddScoped<IRepository<Student>, EFCoreRepository>();

            services.AddDbContext<IdentityDbContext>(options => {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], b => { b.MigrationsAssembly("AspNetCoreFromCli"); });
            });

            services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<IdentityDbContext>();

            services.AddDefaultIdentity<IdentityUser>()//options => options.SignIn.RequireConfirmedAccount = true
      .AddEntityFrameworkStores<IdentityDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });
        }
      
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IConfiguration configuration,
            IWelComeServices welComeServices
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.Use(next =>
            {
                return async httpContext =>
                {
                    if (httpContext.Request.Path.StartsWithSegments("/first"))
                    {
                        await httpContext.Response.WriteAsync("First!!!");
                    }
                    else
                    {
                        await next(httpContext);
                    }
                };
            });

            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/welcome"
            });

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/node_modules",
                FileProvider=new PhysicalFileProvider(Path.Combine(env.ContentRootPath,"node_modules"))
            });

            //app.UseMvcWithDefaultRoute();
            app.UseAuthentication();
            app.UseMvc(builder=> {
                builder.MapRoute("defaule", "{controller=Home}/{action=Index}/{id?}");
            }); 
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        var welCome = configuration["WelCome"];
            //        var welCome2 = welComeServices.GetMessage();
            //        await context.Response.WriteAsync(welCome2);
            //    });
            //});
        }
    }
}
