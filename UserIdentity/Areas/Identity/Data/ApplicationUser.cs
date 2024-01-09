using Microsoft.AspNetCore.Identity;

namespace UserIdentity.Areas.Identity.Data

{
    public enum YourRoleEnum
    {
        Admin,
        Freelancer,
        Client
    }
    public class ApplicationUser : IdentityUser
    {
        public string? Role { get; set; }
    }
}
