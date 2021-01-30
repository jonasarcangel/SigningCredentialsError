using MyProject.Core.Repositories;
using MyProject.Data;
using MyProject.Data.DbContexts;
using MyProject.Data.Identity;
using MyProject.Data.Identity.DbContexts;
using MyProject.Data.Repositories;
using MyProject.Services;
using MyProject.Services.Content;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MyProject.Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //string identityConnectionString = Configuration.GetConnectionString("IdentityDbConnection");
            //services.AddDbContext<AppIdentityDbContext>(options =>
            //    options.UseMySql(identityConnectionString, MySqlServerVersion.LatestSupportedServerVersion),
            //    ServiceLifetime.Transient);

            //string connectionString = Configuration.GetConnectionString("AppDbConnection");
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion),
            //    ServiceLifetime.Transient);
            //services.AddDatabaseDeveloperPageExceptionFilter();

            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddRoles<IdentityRole>()
            //    .AddDefaultTokenProviders();

            //services.AddTransient<INodeRepository, NodeRepository>();
            //services.AddTransient<INodeService, NodeService>();

            services.AddMyProjectIdentity(Configuration);
            services.AddMyProjectDataProvider(Configuration);
            services.AddMyProjectIdentityRepositories();
            services.AddMyProjectApplicationRepositories();
            services.AddMyProjectServices(Configuration);

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UpdateMyProjectDatabase(Configuration);
            app.UpdateMyProjectIdentityDatabase(Configuration);
            services.UseMyProjectServices(Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
