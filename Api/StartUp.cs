using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using BlazorEcommerceStaticWebApp.Api.Data;
using System.IO;
using System;
using Microsoft.Extensions.Logging;

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
            if (!File.Exists("D:\\home\\school2.db"))
            {

                File.Copy("D:\\home\\site\\wwwroot\\school2.db", "D:\\home\\school2.db");
                File.SetAttributes("D:\\home\\school2.db", FileAttributes.Normal);
            }

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {               
                //options.UseSqlite(Utils.GetSQLiteConnectionString());
                options.UseSqlite("Data source = D:\\home\\school2.db");
                //options.UseSqlite("Data source = D:\\home\\site\\wwwroot\\school.db");
            });

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
        }

        //public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        //{
        //    base.ConfigureAppConfiguration(builder);
        //}

    }
}