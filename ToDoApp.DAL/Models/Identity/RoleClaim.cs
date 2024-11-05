﻿using Microsoft.AspNetCore.Identity;

namespace ToDoApp.DAL.Models.Identity
{
    public class RoleClaim : IdentityRoleClaim<string>
    {
        public virtual Role Role { get; set; }
    }
}