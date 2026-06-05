using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }

    public bool Active { get; set; } = true;
}