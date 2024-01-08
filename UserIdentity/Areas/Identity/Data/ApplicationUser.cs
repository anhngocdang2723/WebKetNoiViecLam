using Microsoft.AspNetCore.Identity;

namespace UserIdentity.Areas.Identity.Data

{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
