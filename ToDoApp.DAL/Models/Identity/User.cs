using Microsoft.AspNetCore.Identity;
using ToDoApp.DAL.Models.Identity;

namespace ToDoApp.DAL.Models.Identity
{
    public class User : IdentityUser<string>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<UserClaim> Claims { get; set; }
        public virtual ICollection<UserLogin> Logins { get; set; }
        public virtual ICollection<UserToken> Tokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }

    }
}
