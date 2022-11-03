namespace Network.Application.App.Registration.Responses;

public class SignUpDto
{
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public bool Succeeded { get; set; }
    public string? AccessToken { get; set; }
}