namespace Network.Application.App.Auth.Responses;

public class SingInDto
{
    public bool Succeeded { get; set; }
    public string? AccessToken { get; set; }
    public string? Username { get; set; }
    public int Id { get; set; }
}