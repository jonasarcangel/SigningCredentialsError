﻿using MyProject.Data.Identity.DbContexts;
using MyProject.Data.Identity.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyProject.Data.Identity
{
    public static class Extensions
    {
        public static void AddMyProjectIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var provider = configuration["IdentityDbProvider"].ToLower();
            if (string.IsNullOrEmpty(provider))
            {
                provider = "sqlite";
            }
            string connectionString = configuration.GetConnectionString("IdentityDbConnection");
            switch (provider.ToLower())
            {
                case "sqlserver":
                    services.AddDbContext<AppIdentityDbContext>(options =>
                        options.UseSqlServer(connectionString), ServiceLifetime.Transient);
                    services.AddDbContext<SqlServerIdentityDbContext>(options =>
                        options.UseSqlServer(connectionString), ServiceLifetime.Transient);
                    break;
                case "mysql":
                    services.AddDbContext<AppIdentityDbContext>(options =>
                        options.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion),
                        ServiceLifetime.Transient);
                    services.AddDbContext<MySqlIdentityDbContext>(options =>
                        options.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion),
                        ServiceLifetime.Transient);
                    break;
                case "sqlite":
                    if (string.IsNullOrEmpty(connectionString))
                    {
                        var identityDbFilename = configuration["IdentityDbFilename"];
                        if (string.IsNullOrEmpty(identityDbFilename))
                            identityDbFilename = "MyProject-identity.db";
                        var connectionStringBuilder = new Microsoft.Data.Sqlite.SqliteConnectionStringBuilder { DataSource = identityDbFilename };
                        connectionString = connectionStringBuilder.ToString();
                    }
                    services.AddDbContext<AppIdentityDbContext>(options =>
                        options.UseSqlite(connectionString), ServiceLifetime.Transient);
                    services.AddDbContext<SqliteIdentityDbContext>(options =>
                        options.UseSqlite(connectionString), ServiceLifetime.Transient);
                    break;
            }

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, AppIdentityDbContext>();
        }

        public static void UpdateMyProjectIdentityDatabase(this IApplicationBuilder app, IConfiguration configuration)
        {
            var provider = configuration["IdentityDbProvider"].ToLower();
            if (string.IsNullOrEmpty(provider))
            {
                provider = "sqlite";
            }
            switch (provider.ToLower())
            {
                case "sqlite":
                    {
                        app.ProcessDb<SqliteIdentityDbContext>();
                        break;
                    }
                case "mysql":
                    {
                        app.ProcessDb<MySqlIdentityDbContext>();
                        break;
                    }
                case "sqlserver":
                    {
                        app.ProcessDb<SqlServerIdentityDbContext>();
                        break;
                    }
                default:
                    {
                        throw new Exception();
                    }
            }
        }

        private static void ProcessDb<T>(this IApplicationBuilder app) where T : AppIdentityDbContext
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<T>();
            context.Database.Migrate();
        }

        public static void AddMyProjectIdentityRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }


    }
}
