using System;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class User : IdentityUser
    {
        public string DisplayName { get; set; }
        // public Address Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}