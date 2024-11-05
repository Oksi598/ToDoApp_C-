using Microsoft.AspNetCore.Identity;

namespace ToDoApp.DAL.Models.Identity
{
    public class UserLogin : IdentityUserLogin<string>
    {
        public virtual User User { get; set; }
    }
}
