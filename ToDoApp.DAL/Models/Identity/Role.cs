﻿using Microsoft.AspNetCore.Identity;

namespace ToDoApp.DAL.Models.Identity
{
    public class Role : IdentityRole<string>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
