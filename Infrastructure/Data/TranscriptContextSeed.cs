using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class TranscriptContextSeed
    {
        public static async Task SeedAsync(TranscriptContext context, UserManager<User> userManager, RoleManager<AppRole> roleManager, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryforAvailability = retry.Value;

            try
            {
                await context.Database.MigrateAsync();

                if (userManager.Users.Any()) return;

                var user = new User
                {
                    DisplayName = "Gbubemi Smith",
                    Email = "gsmith@test.com",
                    UserName = "gsmith@test.com",
                    FirstName = "Gbubemi",
                    LastName = "Smith"
                };

                var roles = new List<AppRole>
                {
                    new AppRole{ Name = Role.Admin},
                    new AppRole{ Name = Role.SchoolUser},
                    new AppRole{ Name = Role.User}
                };


                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, Role.User);

                var adminUser = new User
                {
                    DisplayName = "Admin",
                    Email = "admin@test.com",
                    UserName = "admin",
                    FirstName = "admin",
                    LastName = "admin"
                };

                await userManager.CreateAsync(adminUser, "Pa$$w0rd");
                await userManager.AddToRolesAsync(adminUser, new[] { Role.Admin, Role.SchoolUser });

            }
            catch (Exception ex)
            {
                if (retryforAvailability < 3)
                {
                    retryforAvailability++;
                    var log = loggerFactory.CreateLogger<TranscriptContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(context, userManager, roleManager, loggerFactory, retryforAvailability);
                }
            }
        }
    }
}