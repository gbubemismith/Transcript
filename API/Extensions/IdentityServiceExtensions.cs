using System;
using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            try
            {
                var builder = services.AddIdentityCore<User>();

                builder = new IdentityBuilder(builder.UserType, builder.Services);
                builder.AddEntityFrameworkStores<AppIdentityDbContext>();
                builder.AddSignInManager<SignInManager<User>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in extension::" + ex.Message);
            }


            return services;

        }
    }
}