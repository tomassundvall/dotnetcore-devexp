using Microsoft.AspNetCore.Identity;

namespace TSundvall.DotnetCoreDevExp.Identity.Model
{
    public class AppUser : IdentityUser
    {
        public int Id { get; set; }
    }
}
