using Microsoft.AspNetCore.Identity;

namespace Core
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }
}