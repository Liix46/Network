namespace Network.Application.App.Registration.Responses;

public class SignUpDto
{
    public bool Succeeded { get; set; }
    public string? AccessToken { get; set; }
    public string? Username { get; set; }
    public int Id { get; set; }
}