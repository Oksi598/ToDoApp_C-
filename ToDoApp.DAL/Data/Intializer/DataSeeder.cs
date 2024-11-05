﻿using ToDoApp.DAL.Models.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace ToDoApp.DAL.Data.Initializer
{
    public static class DataSeeder
    {
        public static async void SeedData(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

                if (!roleManager.Roles.Any())
                {
                    var adminRole = new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = Settings.AdminRole
                    };

                    var userRole = new Role
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = Settings.UserRole
                    };

                    await roleManager.CreateAsync(adminRole);
                    await roleManager.CreateAsync(userRole);
                }

                if (!userManager.Users.Any())
                {
                    var admin = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "admin@gmail.com",
                        UserName = "admin",
                        EmailConfirmed = true,
                        FirstName = "Admin",
                        LastName = "Admin"
                    };

                    var user = new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "user@gmail.com",
                        UserName = "user",
                        EmailConfirmed = true,
                        FirstName = "User",
                        LastName = "User"
                    };


                    await userManager.CreateAsync(admin, "qwerty");
                    await userManager.CreateAsync(user, "qwerty");

                    await userManager.AddToRoleAsync(admin, Settings.AdminRole);
                    await userManager.AddToRoleAsync(user, Settings.UserRole);
                }
            }
        }
    }
}