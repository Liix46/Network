using Microsoft.AspNetCore.Identity;
using Network.Application.Common.Interfaces;
using Network.Domain.Models;
using Network.Domain.Auth;

namespace Network.Infrastructure.Identity;

public class RegistrationService : IRegistrationService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public RegistrationService(UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<bool> CreateAsync(User user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded;
    }

    // public async Task<bool> AddRoleAsync(User user, string nameRole)
    // {
    //     var result = await  _userManager.AddToRoleAsync(user, nameRole);
    //     return result.Succeeded;
    // }
}