namespace Network.Application.Common.Interfaces;

public interface IAuthenticationService
{
    Task<bool> PasswordSignInAsync(string username, string password);
    
}