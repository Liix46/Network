using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Network.Domain.Models;

public class User : IdentityUser<int>
{
    public string? Name { get; set; }
    public string? Bio { get; set; }
    public Gender Gender { get; set; }
    public string? UrlMainImage { get; set; }
    
    [JsonIgnore]
    public ICollection<Post>? Posts { get; set; }
    public ICollection<Like>? Likes { get; set; }

    public ICollection<Follower>? Followers { get; set; } = new List<Follower>();
    [JsonIgnore] 
    public ICollection<Following?> Followings { get; set; } = new List<Following?>();
    
    [JsonIgnore]
    public ICollection<Comment>? Comments { get; set; }
}

public enum Gender
{
    Male,
    Female
}