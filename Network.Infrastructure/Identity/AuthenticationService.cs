using Microsoft.AspNetCore.Identity;
using Network.Application.Common.Interfaces;
using Network.Domain;

namespace Network.Infrastructure.Identity;

public class AuthenticationService : IAuthenticationService
{
    private readonly SignInManager<User> _signInManager;
    
    public AuthenticationService(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }
    
    public async Task<bool> PasswordSignInAsync(string userName, string password)
    {
        var checkingPasswordResult = await _signInManager.PasswordSignInAsync(userName, password, false, false);

        return checkingPasswordResult.Succeeded;
    }
}