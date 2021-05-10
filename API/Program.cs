using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // await CreateAndSeedDatabase(host);



            using (var scope = host.Services.CreateScope())
            {
                Console.WriteLine("In program.cs");

                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var dbContext = services.GetRequiredService<TranscriptContext>();
                try
                {
                    Console.WriteLine("In try 1");
                    Console.WriteLine("Check::" + dbContext.GetService<IRelationalDatabaseCreator>().Exists());
                    //check if database schema exist
                    if (!(dbContext.GetService<IRelationalDatabaseCreator>().Exists()))
                    {
                        Console.WriteLine("In try 2");
                        var userManager = services.GetRequiredService<UserManager<User>>();
                        var roleManager = services.GetRequiredService<RoleManager<AppRole>>();

                        await TranscriptContextSeed.SeedAsync(dbContext, userManager, roleManager, loggerFactory);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }

            host.Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}
