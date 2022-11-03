using Microsoft.AspNetCore.Identity;
using Network.Application.Common.Interfaces;
using Network.Domain;

namespace Network.Infrastructure.Identity;

public class RegistrationService : IRegistrationService
{
    private readonly UserManager<User> _userManager;

    public RegistrationService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> CreateAsync(User user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded;
    }
}