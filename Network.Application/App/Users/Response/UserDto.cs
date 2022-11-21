using Network.Domain.Models;

namespace Network.Application.App.Users.Response;

public class UserDto
{
    public string? Username { get; set; }
    public string? Name { get; set; }
    public string? Bio { get; set; }
    public Gender Gender { get; set; }
    public string? UrlMainImage { get; set; }
}