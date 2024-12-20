﻿using Microsoft.AspNetCore.Identity;

namespace ToDoApp.DAL.Models.Identity
{
    public class UserClaim : IdentityUserClaim<string>
    {
        public virtual User User { get; set; }
    }
}
