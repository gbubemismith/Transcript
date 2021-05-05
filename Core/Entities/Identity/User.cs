using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SchoolId { get; set; }
        public School Schools { get; set; }
        public ICollection<TranscriptRequest> TranscriptRequests { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }


    }
}