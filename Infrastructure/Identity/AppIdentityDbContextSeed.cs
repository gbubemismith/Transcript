using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<User> userManager, RoleManager<AppRole> roleManager)
        {
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

        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // var roles = new List<AppRole>
            // {
            //     new AppRole{ Name = Role.Admin},
            //     new AppRole{ Name = Role.SchoolUser},
            //     new AppRole{ Name = Role.User}
            // };


            // foreach (var role in roles)
            // {
            //     await roleManager.CreateAsync(role);
            // }

            await roleManager.CreateAsync(new IdentityRole(Role.Admin));
            await roleManager.CreateAsync(new IdentityRole(Role.SchoolUser));
            await roleManager.CreateAsync(new IdentityRole(Role.User));


        }
    }
}