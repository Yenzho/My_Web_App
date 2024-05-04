using Microsoft.AspNetCore.Identity;

namespace WebApplicationTry.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsBlocked { get; set; }
    }
}
