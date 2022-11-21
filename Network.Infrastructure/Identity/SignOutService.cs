using Microsoft.AspNetCore.Identity;
using Network.Application.Common.Interfaces;
using Network.Domain.Models;

namespace Network.Infrastructure.Identity;

public class SignOutService : ISignOutService
{
    private readonly SignInManager<User> _signInManager;

    public SignOutService(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task SignOut()
    {
        // delete authentication cookies
        await _signInManager.SignOutAsync();
    }
}