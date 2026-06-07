using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ProfilePicture { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
