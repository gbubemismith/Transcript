using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    DisplayName = "Gbubemi",
                    Email = "gsmith@test.com",
                    UserName = "gsmith@test.com"

                };

                await userManager.CreateAsync(user, "Pa$$w0rd");

            }
        }
    }
}