using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using BlazorEcommerceStaticWebApp.Api.Data;
using System.IO;
using System;

[assembly: FunctionsStartup(typeof(BlazorEcommerceStaticWebApp.Api.StartUp))]
namespace BlazorEcommerceStaticWebApp.Api
{
    public class StartUp : FunctionsStartup
    {
        const string DevEnvValue = "Development";
        const string DBPath = "school.db";
        public const string Azure_DBPath = "D:/home/school.db";

        private static void CopyDb()
        {
            File.Copy(DBPath, Azure_DBPath);
            File.SetAttributes(Azure_DBPath, FileAttributes.Normal);
        }
        public override void Configure(IFunctionsHostBuilder builder)
        {
            bool isDevEnv = Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT") == DevEnvValue ? true : false;

            if(!isDevEnv && !File.Exists(Azure_DBPath))
            {
                CopyDb();
            }

            if (isDevEnv)
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite(Utils.GetSQLiteConnectionString());
                });
            }
            else
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite(Azure_DBPath);
                });
            }
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            base.ConfigureAppConfiguration(builder);
        }

    }
}