using Microsoft.AspNetCore.Identity;

namespace Network.Domain;

public class User : IdentityUser<int>
{
    public string? Name { get; set; }
    public string? Bio { get; set; }
    public Gender Gender { get; set; }
    public string? UrlMainImage { get; set; }

    public List<Post>? Posts { get; set; }
    
}

public enum Gender
{
    Male,
    Female
}