using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using BlazorEcommerceStaticWebApp.Api.Data;
using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Api.Services.ProductService;

[assembly: FunctionsStartup(typeof(BlazorEcommerceStaticWebApp.Api.StartUp))]
namespace BlazorEcommerceStaticWebApp.Api
{
    public class StartUp : FunctionsStartup
    {

        //const string DevEnvValue = "Development";
        //const string DBPath = "./appdata/school.db";
        //// public in case we need it elsewhere in the API
        //public const string Azure_DBPath = "d:\\home\\site\\wwwroot\\school.db";

        //private static void CopyDb()
        //{
        //    File.Copy(DBPath, Azure_DBPath);
        //    File.SetAttributes(Azure_DBPath, FileAttributes.Normal);
        //}

        public override void Configure(IFunctionsHostBuilder builder)
        {
            if (Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT") != "Development")
            {
                if (!File.Exists("D:\\home\\ecommerce.db"))
                {

                    File.Copy("D:\\home\\site\\wwwroot\\ecommerce.db", "D:\\home\\ecommerce.db");
                    File.SetAttributes("D:\\home\\ecommerce.db", FileAttributes.Normal);
                }

                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    //options.UseSqlite(Utils.GetSQLiteConnectionString());
                    options.UseSqlite("Data source = D:\\home\\ecommerce.db");
                    //options.UseSqlite("Data source = D:\\home\\site\\wwwroot\\school.db");
                });
            }
            else
            {
                builder.Services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlite(Utils.GetSQLiteConnectionString());
                });

            }

            //    var s = Utils.GetSQLiteConnectionString();

            //    bool isDevEnv = Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT") == DevEnvValue ? true : false;
            //    // One time copy of the DB (per deployment)
            //    if (!isDevEnv && !File.Exists(Azure_DBPath))
            //        CopyDb();


            //    builder.Services.AddDbContext<ApplicationDbContext>(options =>
            //    {
            //        Console.WriteLine("Dev dbContext");
            //        options.UseSqlite($"data source={(isDevEnv ? DBPath : Azure_DBPath)};");
            //    });

            //    //builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(
            //    //         (s, o) => o
            //    //           .UseSqlite($"data source={(isDevEnv ? DBPath : Azure_DBPath)};")
            //    //           //.UseLoggerFactory(s.GetRequiredService<ILoggerFactory>())
            //    //           );

            builder.Services.AddScoped<IProductService, ProductService>();

        }

        //public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        //{
        //    base.ConfigureAppConfiguration(builder);
        //}

    }
}